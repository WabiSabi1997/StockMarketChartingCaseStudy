using DataCreationMicroservice.Context;
using Newtonsoft.Json.Linq;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorMicroservice.Repositories
{
    public class SectorRepository : IRepository<Sector>
    {
        private StockMarketContext context;

        public SectorRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(Sector entity)
        {
            context.Add(entity);
            var isChanged = context.SaveChanges();

            if (isChanged > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Sector> Get()
        {
            var sectors = context.Sectors;
            return sectors;
        }

        public Sector Get(object key)
        {
            var res = context.Sectors.Find(key);
            return res;
        }

        Object IRepository<Sector>.GetCompanies(Sector res)
        {
            var CompanyList = context.Companies.Where(s => s.Sector.SectorID == res.SectorID).Select(s => s.CompanyName).ToList();
            return CompanyList;
        }

        Object IRepository<Sector>.GetSectorPrice(int id, DateTime from, DateTime to)
        {   //to figure out periodicity later
            var CompanyIdList = context.Companies.Where(s => s.Sector.SectorID == id).Select(s => s.CompanyId); //res returns a list of CompanyId(s)

            List<double> CompanyAvgList = new List<double>();
            double sum = 0;
            int count = 0;
            foreach (var Id in CompanyIdList) //for each company Id
            {
                var CompanyStockPrices = context.StockPrices.Where(s => s.CompanyId == Id); //instances of StockPrices where the company ID matches
                sum = 0;
                count = 0;
                foreach (var res in CompanyStockPrices)
                {
                    DateTime resDate = Convert.ToDateTime(string.Concat(res.Date, " ", res.Time));
                    if (resDate >= from && resDate <= to)
                    {
                        sum += (double)res.CurrentPrice;
                        count++;
                    }
                }
                CompanyAvgList.Add(sum / count);
            }
            double SectorPrice = CompanyAvgList.Sum()/CompanyAvgList.Count();

            return SectorPrice;
        }
        
    }
}

using DataCreationMicroservice.Context;
using DataCreationMicroservice.StockMarket.DTOs;
using Microsoft.EntityFrameworkCore;

using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private StockMarketContext context;

        public CompanyRepository(StockMarketContext context)
        {
            this.context = context;
        }
        
         public bool Add(CompanyDto entity) //adding a company
        {
            try
            {
                var company = new Company
                {
                    CompanyName = entity.CompanyName,
                    Turnover = entity.Turnover,
                    CEO = entity.CEO,
                    BoardOfDirectors = entity.BoardOfDirectors,
                    Brief = entity.Brief
                   //we are also getting stock exchange ID here
                };
                company.Sector = context.Sectors.Find(entity.SectorId);
                var sector = context.Sectors.Find(entity.SectorId);

                context.Companies.Add(company);

                //ICollection<Company> a = new HashSet<Company>();
                //a.Add(company);
                sector.Companies.Add(company);
                context.Sectors.Update(sector);

                //sector.Companies.Add(company);

                //company.CompanyId get this
                // do the below via adding object of StockExchangeCompanies
                // StockExchangeCompanies = context.StockExchangeCompanies.Add(company.CompanyId, company.StockExchangeId)

                for (int i = 0; i < entity.StockExchangeIds.Count(); i++)
                {
                    var sid = entity.StockExchangeIds[i];
                    var sec = new StockExchangeCompany
                    {
                        Company = company,
                        StockExchange = context.StockExchanges.Find(sid)
                    };
                    
                    context.StockExchangeCompanies.Add(sec); 
                }

                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        /* OLD add company
         * context.Companies.Add(entity);
            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false; */

        public IEnumerable<CompanyDto> Get()
        {
            var companies = context.Companies;
            var ls = new HashSet<CompanyDto>();
            foreach (var comp in companies)
            {
                CompanyDto b = new CompanyDto();
                b.CompanyId = comp.CompanyId;
                b.BoardOfDirectors = comp.BoardOfDirectors;
                b.CompanyName = comp.CompanyName;
                b.Turnover = comp.Turnover;
                b.CEO = comp.CEO;
                b.Brief = comp.Brief;
                //var x= context.Companies.Find(comp.CompanyId).Sector.SectorID;
                
                //var a = comp.Sector.SectorID;
                //b.SectorId = comp.Sector.SectorID;
                //b.StockExchangeIds = comp.StockExchangeCompanies.Select(s=>s.StockExchangeId).ToList();
                ls.Add(b);
            }

            return ls;
        }

      
        public bool Delete(Object entity)
        {
            context.Remove(entity);
            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false;
        }

        public object GetbyName(string query)
        {
            var res = context.Companies.Where(c => c.CompanyName.Contains(query)).Select(c => c.CompanyName).ToList();
            if (res.Count == 0)
            {
                return null;
            }
            return res;
        }

            public object GetStockPrice(int id, DateTime from, DateTime to)
        {
            var res = context.StockPrices.Where(s => s.CompanyId == id);
            List<Object> res2 = new List<Object>();
            foreach (var res1 in res)
            {
                DateTime res1Date = Convert.ToDateTime(string.Concat(res1.Date, " ", res1.Time));
                if (res1Date >= from && res1Date <= to)
                {
                    Tuple<double, DateTime> t = new Tuple<double, DateTime>(res1.CurrentPrice, res1Date);
                    res2.Add(t);
                }
            }
            return res2;
        }

        
        public bool Update(CompanyDto entity)
        {
            var comp = new Company()
            {
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                BoardOfDirectors = entity.BoardOfDirectors,
                CEO = entity.CEO,
                Brief = entity.Brief,
                Turnover = entity.Turnover
            };
            var sector = context.Sectors.Find(entity.SectorId);
            comp.Sector = sector;
            context.Entry(comp).State = EntityState.Modified;

            sector.Companies.Add(comp);
            context.Sectors.Update(sector);

            //ICollection<StockExchangeCompany> secList = new HashSet<StockExchangeCompany>();

            //var abc = context.StockExchangeCompanies.Where(s => s.CompanyId == comp.CompanyId);
            //foreach (var a in abc)
            //{
            //    context.StockExchangeCompanies.Remove(a);
            //}

            //for (int i = 0; i < entity.StockExchangeIds.Count(); i++)
            //{
            //    var sid = entity.StockExchangeIds[i];
            //    var sec = new StockExchangeCompany
            //    {
            //        Company = comp,
            //        StockExchange = context.StockExchanges.Find(sid)
            //    };

            //    var ab = context.StockExchangeCompanies.Find(comp.CompanyId,sid);
            //    //if (ab == null)
            //    //{
            //    //    secList.Add(sec);
            //    //}
            //    context.StockExchangeCompanies.Add(sec);
            //}
            //comp.StockExchangeCompanies = secList;
            //context.Entry(comp).State = EntityState.Modified;

            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false;
        }
        
        public object Get(object key)
        {
            var res = context.Companies.Find(key);
            return res;
        }

        public bool Add(object entity)
        {
            throw new NotImplementedException();
        }

      
    }
}

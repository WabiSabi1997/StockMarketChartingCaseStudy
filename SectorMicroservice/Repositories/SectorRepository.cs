//using SectorMicroservice.Contexts;
using StockExchangeMicroservice.Contexts;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorMicroservice.Repositories
{
    public class SectorRepository : IRepository<Sector>
    {
        private StockExchangeContext context;

        public SectorRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        public bool Add(Sector entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Sector entity)
        {
            throw new NotImplementedException();
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

        public bool Update(Sector entity)
        {
            throw new NotImplementedException();
        }

        Object IRepository<Sector>.GetCompanies(Sector res)
        {
           // var temp = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).Select(s => s.CompanyId).ToList();
            var temp2 = context.Companies.Where(s => s.Sector.SectorID == res.SectorID).Select(s => s.CompanyName).ToList();
            return temp2;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StockExchangeMicroservice.Contexts;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private StockExchangeContext context;

        public CompanyRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        public bool Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Get()
        {
            var companies = context.Companies;
            return companies;
        }



        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }

        Object IRepository<Company>.GetIPO(int key)
        {
            var res = context.IPODetails.Where(s => s.CompanyId == key).ToList();
            return res;
        }

        Object IRepository<Company>.GetStockPrice(int id, DateTime from, DateTime to)
        {
            //var res = context.StockPrices.Where(s => s.CompanyId == id);
            //var res1 = res.FromSql(;
            //var res2 = res1.Select(s => s.CurrentPrice).ToList();
            //var res2 = context.StockPrices.FromSqlRaw($"Select CurrentPrice from StockPrices Where StockPrices.CompanyId={id} and StockPrices.Date>={from} and StockPrices.Date<={to}");

            var res = context.StockPrices.Where(s => s.CompanyId == id);
            List<Object> res2 = new List<Object>();
            foreach (var res1 in res)
            {
                DateTime res1Date = Convert.ToDateTime(string.Concat(res1.Date, " ", res1.Time));
                if(res1Date >= from && res1Date <= to)
            res2.Add(res1.CurrentPrice);
            }
            return res2;
        }
    }
}

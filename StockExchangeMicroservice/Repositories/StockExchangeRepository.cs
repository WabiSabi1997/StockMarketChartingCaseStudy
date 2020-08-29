using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StockExchangeMicroservice.Contexts;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StockExchangeMicroservice.Repositories
{
    public class StockExchangeRepository : IRepository<StockExchange>
    {
        private StockExchangeContext context;

        public StockExchangeRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchange entity)
        {
            StockExchange temp = entity;
            temp.StockExchangeCompanies = null;

            //StockExchangeCompanies temp2 = entity.StockExchangeCompanies;
            return true;
        }

        public bool Delete(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> Get()
        {
            //This line is to get all the stock exchange entries in the stock exchange database table
            var stockexchanges = context.StockExchanges;
            return stockexchanges;
        }

        public StockExchange Get(object key)
        {
                var res = context.StockExchanges.Find(key);
                return res;
        }

        //public ICollection<Company> GetCompanies(StockExchange res)
        //{

        //}

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }

         Object IRepository<StockExchange>.GetCompanies(StockExchange res)
        {
            var temp = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).Select(s => s.CompanyId).ToList();
            var temp2 = context.Companies.Where(s => temp.Contains(s.CompanyId)).Select(s => s.CompanyName);
            return temp2;

        }
    }
}

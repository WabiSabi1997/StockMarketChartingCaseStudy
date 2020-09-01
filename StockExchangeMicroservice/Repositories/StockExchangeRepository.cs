using DataCreationMicroservice.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        private StockMarketContext context;

        public StockExchangeRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchange entity)
        {
            //We can use this code to find any existing stock exchange with such a name/id etc.
            //var temp = context.StockExchangeCompanies.Find(id,entity.StockExchangeID);
            //entity.StockExchangeCompanies = new HashSet<StockExchangeCompany> { temp };

            context.StockExchanges.Add(entity);
            var changes = context.SaveChanges();
            if (changes > 0)
            {
                return true;
            }
            return false;
        }

        public bool Add(int id, int id2)
        {
            //First get the stock exchange with the given id. 
            //Then create an object of StockExchangeCompanies with the stock exchange id and company field.
            //Add the company to the stock exchange using this stockexchange companies np.

            var se = context.StockExchanges.Find(id);
            //Check if the company exists or not too. Assuming that it does, the code shall be as follows
            var entity = context.Companies.Find(id2);
            var ipo = context.IPODetails.Single(s => s.StockExchangeCompany.StockExchangeId == id && s.StockExchangeCompany.CompanyId == id2);

            var sec = new StockExchangeCompany
            {
                Company = entity,
                StockExchange = se
            };

            context.StockExchangeCompanies.Add(sec);
            var res = context.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            return false;
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
            //res.StockExchangeCompanies = context.StockExchangeCompanies.Where(s=> s.StockExchangeId == res.StockExchangeID).ToList();
            return res;
        }

        //public StockExchange Get1(object key)
        //{
        //    var res = context.StockExchanges.Find(key);
        //    res.StockExchangeCompanies = context.StockExchangeCompanies.Where(s=> s.StockExchangeId == res.StockExchangeID).ToList();
        //    return res;
        //}

        //public ICollection<Company> GetCompanies(StockExchange res)
        //{

        //}

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        object IRepository<StockExchange>.GetExchange(int id)
        {
            var res = context.StockExchanges.Find(id);
            var sec = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).ToList();
            return sec;
        }

        Object IRepository<StockExchange>.GetCompanies(StockExchange res)
        {
            var temp = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).Select(s => s.CompanyId).ToList();
            var temp2 = context.Companies.Where(s => temp.Contains(s.CompanyId)).Select(s => s.CompanyName);
            return temp2;
        }
    }
}

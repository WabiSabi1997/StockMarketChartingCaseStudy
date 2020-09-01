using DataCreationMicroservice.Context;
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
        public bool Add(Company entity) //adding a company
        {
            context.Companies.Add(entity);
            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Company> Get()
        {
            var companies = context.Companies;
            return companies;
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
                    res2.Add(res1.CurrentPrice);
            }
            return res2;
        }

        public bool Update(Company entity)
        {
            context.Entry(entity).State = EntityState.Modified;
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
    }
}

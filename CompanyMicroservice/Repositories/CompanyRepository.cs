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
                    Brief = entity.Brief,
                    Sector = context.Sectors.Find(entity.SectorId),
                   //we are also getting stock exchange ID here
                };
                context.Companies.Add(company);

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
            return (IEnumerable<CompanyDto>)companies;
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

        
        public bool Update(CompanyDto entity)
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

        public bool Add(object entity)
        {
            throw new NotImplementedException();
        }

      
    }
}

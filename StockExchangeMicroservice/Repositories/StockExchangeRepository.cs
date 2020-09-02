using DataCreationMicroservice.Context;
using DataCreationMicroservice.StockMarket.DTOs;
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
    public class StockExchangeRepository : IRepository<StockExchangeDto>
    {
        private StockMarketContext context;

        public StockExchangeRepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchangeDto entity)
        {
            //We can use this code to find any existing stock exchange with such a name/id etc.
            //var temp = context.StockExchangeCompanies.Find(id,entity.StockExchangeID);
            //entity.StockExchangeCompanies = new HashSet<StockExchangeCompany> { temp };
            try
            {
                var stockexchange = new StockExchange
                {
                    StockExchangeName = entity.StockExchangeName,
                    Brief = entity.Brief,
                    ContactAddress = entity.ContactAddress,
                    Remarks = entity.Remarks
                };
                context.StockExchanges.Add(stockexchange);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


           
        }
        /*
         * context.StockExchanges.Add(entity);
            var changes = context.SaveChanges();
            if (changes > 0)
            {
                return true;
            }
            return false;
        */

        public bool Add(int id, int id2)
        {
            //First get the stock exchange with the given id. 
            //Then create an object of StockExchangeCompanies with the stock exchange id and company field.
            //Add the company to the stock exchange using this stockexchange companies np.

            var se = context.StockExchanges.Find(id);
            //Check if the company exists or not too. Assuming that it does, the code shall be as follows
            var entity = context.Companies.Find(id2);
            //var ipo = context.IPODetails.Single(s => s.StockExchangeCompany.StockExchangeId == id && s.StockExchangeCompany.CompanyId == id2);

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

        public bool Delete(StockExchangeDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockExchangeDto> Get()
        {
            //This line is to get all the stock exchange entries in the stock exchange database table
            var stockexchanges = context.StockExchanges;
            
            return (IEnumerable<StockExchangeDto>)stockexchanges;
        }

        public StockExchangeDto Get(object key)
        {
            var res = context.StockExchanges.Find(key);
            //res.StockExchangeCompanies = context.StockExchangeCompanies.Where(s=> s.StockExchangeId == res.StockExchangeID).ToList();
            var res2 = new StockExchangeDto
            {
                StockExchangeID = res.StockExchangeID,
                StockExchangeName=res.StockExchangeName,
                ContactAddress = res.ContactAddress,
                Brief = res.Brief,
                Remarks = res.Remarks
            };
            return res2;
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

        public bool Update(StockExchangeDto entity)
        {
            throw new NotImplementedException();
        }

        object IRepository<StockExchangeDto>.GetExchange(int id)
        {
            var res = context.StockExchanges.Find(id);
            var sec = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).ToList();
            return sec;
        }

        Object IRepository<StockExchangeDto>.GetCompanies(StockExchangeDto res)
        {
            var temp = context.StockExchangeCompanies.Where(s => s.StockExchangeId == res.StockExchangeID).Select(s => s.CompanyId).ToList();
            var temp2 = context.Companies.Where(s => temp.Contains(s.CompanyId)).Select(s => s.CompanyName).ToList();
            return temp2;
        }
    }
}

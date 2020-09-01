using CompanyMicroservice.Controllers;
using DataCreationMicroservice.Context;
using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
    public class IPORepository : IRepository<IPODetail>

    {
        private StockMarketContext context;

        public IPORepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(IPODetail entity) //adding an IPO
        {
            context.IPODetails.Add(entity);
            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPODetail> Get()
        {
            throw new NotImplementedException();
        }

        public Object Get(object key) //to get IPO based on company ID
        {
            var res = context.IPODetails.Where(s => s.CompanyId ==(int) key).ToList();
            return res;
        }

        public bool Update(IPODetail entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            var x = context.SaveChanges();
            if (x > 0)
            {
                return true;
            }
            return false;
        }
    }
}

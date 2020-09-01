using CompanyMicroservice.Controllers;
using DataCreationMicroservice.Context;
using DataCreationMicroservice.StockMarket.DTOs;
using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
    public class IPORepository : IRepository<IPODetailsDto>

    {
        private StockMarketContext context;

        public IPORepository(StockMarketContext context)
        {
            this.context = context;
        }
        public bool Add(IPODetailsDto entity) //adding an IPO
        {
            try
            {
                var IPODetail = new IPODetail
                {
                    PricePerShare = entity.PricePerShare,
                    TotalNumOfShares = entity.TotalNumOfShares,
                    OpenDate = entity.OpenDate,
                    OpenTime = entity.OpenTime,
                    Remarks = entity.Remarks,
                    StockExchangeCompany = context.StockExchangeCompanies.Find(entity.CompanyId, entity.StockExchangeId)

                };
                context.IPODetails.Add(IPODetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

          
        }

     

        public bool Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPODetailsDto> Get()
        {
            throw new NotImplementedException();
        }

        public Object Get(object key) //to get IPO based on company ID
        {
            var res = context.IPODetails.Where(s => s.StockExchangeCompany.CompanyId ==(int) key).ToList();
            return res;
        }

        public bool Update(IPODetailsDto entity)
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

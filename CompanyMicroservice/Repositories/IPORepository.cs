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
                    //  StockExchangeCompany = context.StockExchangeCompanies.Find(entity.CompanyId, entity.StockExchangeId)
                    StockExchangeId = entity.StockExchangeId,
                    CompanyId=entity.CompanyId
                       
                };
                IPODetail.Company = context.Companies.Find(entity.CompanyId);
                IPODetail.StockExchange = context.StockExchanges.Find(entity.StockExchangeId);
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
        {   //we need to get all ipo details
            var res = context.IPODetails;
            var IPODetailsDtoList = new HashSet<IPODetailsDto>();
            foreach (var IPO in res)
            {
                var IPODetailInstance = new IPODetailsDto();
                IPODetailInstance.IPODetailID = IPO.IPODetailID;
                IPODetailInstance.PricePerShare = IPO.PricePerShare;
                IPODetailInstance.TotalNumOfShares = IPO.TotalNumOfShares;
                IPODetailInstance.OpenDate = IPO.OpenDate;
                IPODetailInstance.OpenTime = IPO.OpenTime;
                IPODetailInstance.Remarks = IPO.Remarks;
                IPODetailInstance.CompanyId = IPO.CompanyId;
                IPODetailInstance.StockExchangeId = IPO.StockExchangeId;
                
            }

         
            return IPODetailsDtoList;
           // throw new NotImplementedException();
        }

        public Object Get(object key) //to get IPO based on company ID
        {
            var res = context.IPODetails.Where(s => s.CompanyId ==(int) key).ToList();
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

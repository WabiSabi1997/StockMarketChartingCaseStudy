using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyMicroservice.Repositories
{
   public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);// { }
        bool Delete(object entity);// { }
        IEnumerable<T> Get();
        Object Get(object key);
       

        //object GetCompanies(Sector res);
    }
}

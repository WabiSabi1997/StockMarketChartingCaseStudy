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
        bool Delete(T entity);// { }
        IEnumerable<T> Get();
        Object GetIPO(int key);
        object GetStockPrice(int id, DateTime from, DateTime to);
        object GetbyName(string query);

        //object GetCompanies(Sector res);
    }
}

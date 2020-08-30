using Newtonsoft.Json.Linq;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SectorMicroservice.Repositories
{
   public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);// { }
        bool Delete(T entity);// { }
        IEnumerable<T> Get();
        T Get(object key);
        object GetCompanies(Sector res);
        object GetSectorPrice(int id, DateTime from, DateTime to);
    }
}

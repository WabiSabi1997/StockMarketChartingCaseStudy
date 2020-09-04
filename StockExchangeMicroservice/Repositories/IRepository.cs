using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeMicroservice.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        IEnumerable<T> Get();
        T Get(object key);
        object GetCompanies(T res);
        bool Add(int id, int id2);
        object GetExchange(int id);
    }
}

using StockExchangeMicroservice.Contexts;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeMicroservice.Repositories
{
    public class StockExchangeRepository : IRepository<StockExchange>
    {
        private StockExchangeContext context;

        public StockExchangeRepository(StockExchangeContext context)
        {
            this.context = context;
        }
        public bool Add(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StockExchange entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockExchange> Get()
        {
            //This line is to get all the stock exchange entries in the stock exchange database table
            var stockexchanges = context.StockExchanges;
            return stockexchanges;
        }

        public StockExchange Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockExchange entity)
        {
            throw new NotImplementedException();
        }
    }
}

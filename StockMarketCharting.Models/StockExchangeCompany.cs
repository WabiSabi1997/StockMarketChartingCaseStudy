using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketCharting.Models
{
   public class StockExchangeCompany
    {
        public string StockExchangeId { get; set; }
        public StockExchange StockExchange { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

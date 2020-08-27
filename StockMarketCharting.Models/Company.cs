using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
//using System.Collections;

namespace StockMarketCharting.Models
{
   

        public class Company
        {
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public double Turnover { get; set; }
            public string CEO { get; set; }
            public List<string> BoardOfDirectors { get; set; }

            public string Brief { get; set; }
            //public Dictionary<int, int> CompanyStockCode { get; set; }

        //np
            public virtual Sector Sector { get; set; }
            public virtual ICollection<StockExchange> StockExchanges { get; set; }
            public virtual IPODetail IPODetail { get; set; }
            public virtual ICollection<StockPrice> StockPrices { get; set; }

    }
}


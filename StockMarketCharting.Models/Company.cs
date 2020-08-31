using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
//using System.Collections;

namespace StockMarketCharting.Models
{
   

        public class Company
        {
            [Key]
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public double Turnover { get; set; }
            public string CEO { get; set; }
            //To figure out how to use collection of strings using efcore later.
            public virtual List<string> BoardOfDirectors { get; set; }

            public string Brief { get; set; }
            //public Dictionary<int, int> CompanyStockCode { get; set; }

        //np
            public virtual Sector Sector { get; set; }
            public virtual IPODetail IPODetail { get; set; }
            public virtual ICollection<StockExchangeCompanies> StockExchangeCompanies { get; set; }
            public virtual ICollection<StockPrice> StockPrices { get; set; }

    }
}


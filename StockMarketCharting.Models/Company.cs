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
            public virtual string BoardOfDirectors { get; set; }
            public string Brief { get; set; }
            //public Dictionary<int, int> CompanyStockCode { get; set; }

        //np
            public virtual Sector Sector { get; set; }
           // public virtual IPODetail IPODetail { get; set; } //Company table doesnt have a foreign key to this, should it?
            public virtual ICollection<StockExchangeCompany> StockExchangeCompanies { get; set; }

           // public virtual ICollection<StockPrice> StockPrices { get; set; }

    }
}


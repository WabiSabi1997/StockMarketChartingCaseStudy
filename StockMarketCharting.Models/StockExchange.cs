using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class StockExchange
    {
        public StockExchange()
        {
            StockExchangeCompanies = new HashSet<StockExchangeCompany>();
           // IPODetails = new HashSet<IPODetail>();
           // StockPrices = new HashSet<StockPrice>();
        }
        [Key]
        public int StockExchangeID { get; set; } //takes NSE and BSE etc
        [Required]
        public string StockExchangeName { get; set; }
        public string Brief { get; set; }                       

        public string ContactAddress { get; set; }
        public string Remarks { get; set; }

        //navigation property
        public virtual ICollection<StockExchangeCompany> StockExchangeCompanies { get; set; } // Many to Many and hence a collection
       
        // public virtual ICollection<StockPrice> StockPrices { get; set; } // 1 to *, and hence a collection
       // public virtual ICollection<IPODetail> IPODetails { get; set; } //One to many relationship, one stock exchange can have many IPOs
    }
}

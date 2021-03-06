﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StockMarketCharting.Models
{

    public class StockPrice
    {
        [Key]
        public int StockPriceId { get; set; }
        [Required]
        public double CurrentPrice { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        //np
       // [Required] do we need this?
       // public virtual StockExchangeCompany StockExchangeCompany{get; set;}
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("StockExchange")]
        public int StockExchangeId { get; set; }
        public virtual StockExchange StockExchange { get; set; } // one particular stock price on one particular stock exchange
        
    }
}

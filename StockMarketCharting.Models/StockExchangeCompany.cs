using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
   public class StockExchangeCompany
    {
       // [Required]
        public int StockExchangeId { get; set; }
        public StockExchange StockExchange { get; set; }
       // [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

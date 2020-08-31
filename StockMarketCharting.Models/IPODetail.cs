using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class IPODetail
    {   [Key]
        public int IPODetailID { get; set; }
        [Required]
        public double PricePerShare { get; set; }
        [Required]
        public int TotalNumOfShares { get; set; }
        [Required]
        public string OpenDate{ get; set; }
        [Required]
        public string OpenTime { get; set; }
        public string Remarks { get; set; }

        //Navigation Property
        public int CompanyId { get; set; }
        public string StockExchangeId { get; set; }
        public virtual Company Company { get; set; }
        public virtual StockExchange StockExchange { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StockMarketCharting.Models
{
    public class IPODetail
    {   [Key]
        public long IPODetailID { get; set; }
        [Required]
        public decimal PricePerShare { get; set; }
        [Required]
        public int TotalNumOfShares { get; set; }
        [Required]
        public string OpenDate{ get; set; }
        [Required]
        public string OpenTime { get; set; }
        public string Remarks { get; set; }

        //Navigation Property
        public virtual Company Company { get; set; }
        public virtual StockExchange StockExchange { get; set; }
    }
}

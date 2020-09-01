using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataCreationMicroservice.StockMarket.DTOs
{
    public class IPODetailsDto
    {
        public int IPODetailID { get; set; }
        [Required]
        public double PricePerShare { get; set; }
        [Required]
        public int TotalNumOfShares { get; set; }
        [Required]
        public string OpenDate { get; set; }
        [Required]
        public string OpenTime { get; set; }
        public string Remarks { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int StockExchangeId { get; set; }
       
    }
}

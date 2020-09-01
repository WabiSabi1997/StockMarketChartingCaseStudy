using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataCreationMicroservice.StockMarket.DTOs
{
    public class StockExchangeDto
    {
        public int StockExchangeID { get; set; } //takes NSE and BSE etc
        [Required]
        public string StockExchangeName { get; set; }
        public string Brief { get; set; }

        public string ContactAddress { get; set; }
        public string Remarks { get; set; }

        //We dont have a field for companies here, linking that through companies DTO

    }
}

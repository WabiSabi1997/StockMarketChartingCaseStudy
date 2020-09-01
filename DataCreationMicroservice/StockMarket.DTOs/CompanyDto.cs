using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DataCreationMicroservice.StockMarket.DTOs
{
    public class CompanyDto
    {
        public int CompanyId { get; set; } //not a required field, will only need when editing
        [Required]
        public string CompanyName { get; set; }
        public double Turnover { get; set; }
        public string CEO { get; set; }
        public virtual string BoardOfDirectors { get; set; }
        public string Brief { get; set; }
        [Required]
        public int SectorId { get; set; }
       
        [Required]
        public List<int> StockExchangeIds { get; set; } // because a company can be in 1 or more SE

    }
}

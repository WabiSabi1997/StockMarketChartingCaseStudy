using System;

namespace StockMarketCharting.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    //using System.Collections;

    namespace ClassLibrary1
    {
        public class Company
        {
            public string CompanyName { get; set; }
            public double Turnover { get; set; }
            public string CEO { get; set; }
            public List<string> BoardOfDirectors { get; set; }
            public Dictionary<int, string> ListedSE { get; set; }
            public Dictionary<long, string> Sector { get; set; }
            public string Brief { get; set; }
            public Dictionary<int, int> CompanyStockCode { get; set; }
        }

        public class StockPriceEntity
        {
            public string CompanyCode { get; set; }
            public Dictionary<int, string> StockExchanges { get; set; }
            public double CurrentPrice { get; set; }
            public DateTime Date { get; set; }
            public DateTime Time { get; set; }
        }

        public class IPODetail
        {
            public long ID { get; set; }
            public string CompanyName { get; set; }
            public Dictionary<int, string> StockExchanges { get; set; }
            public double PricePerShare { get; set; }
            public int TotalNumOfShares { get; set; }
            public DateTime OpenDateTime { get; set; }
            public string Remarks { get; set; }
        }

        public class UserEntity
        {
            public long ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public char UserType { get; set; }
            public string Email { get; set; }
            public int Mobile { get; set; }
            public bool Confirmed { get; set; }
        }

        public class StockExchange
        {
            public long ID { get; set; }
            public Dictionary<int, string> StockExchanges { get; set; }
            public string Brief { get; set; }
            public string ContactAddress { get; set; }
            public string Remarks { get; set; }
        }

        public class Sectors
        {
            public long ID { get; set; }
            public string SectorName { get; set; }
            public string Brief { get; set; }
        }

        
    }
}

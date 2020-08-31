using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StockMarketCharting.Models.Context
{
    public class StockMarketContext: DbContext
    {
        
         public StockMarketContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected StockMarketContext()
        {
        }

        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<StockExchangeCompany> StockExchangeCompanies { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<IPODetail> IPODetails { get; set; }
        public virtual DbSet<StockPrice> StockPrices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockExchangeCompany>()
                .HasKey(t => new { t.StockExchangeId, t.CompanyId });
            modelBuilder.Entity<StockExchangeCompany>()
    .HasOne(bc => bc.StockExchange)
    .WithMany(b => b.StockExchangeCompanies)
    .HasForeignKey(bc => bc.StockExchangeId);
            modelBuilder.Entity<StockExchangeCompany>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.StockExchangeCompanies)
                .HasForeignKey(bc => bc.CompanyId);
        }
        //Once implemented companies, add ipdetails and other virtual classes. 

    }
}


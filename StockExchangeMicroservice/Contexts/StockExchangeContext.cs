using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchangeMicroservice.Contexts
{
    public class StockExchangeContext : DbContext
    {
        public StockExchangeContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected StockExchangeContext()
        {
        }

        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<StockExchangeCompanies> StockExchangeCompanies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockExchangeCompanies>()
                .HasKey(t => new { t.StockExchangeId, t.CompanyId });
            modelBuilder.Entity<StockExchangeCompanies>()
    .HasOne(bc => bc.StockExchange)
    .WithMany(b => b.StockExchangeCompanies)
    .HasForeignKey(bc => bc.StockExchangeId);
            modelBuilder.Entity<StockExchangeCompanies>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.StockExchangeCompanies)
                .HasForeignKey(bc => bc.CompanyId);
        }
        //Once implemented companies, add ipdetails and other virtual classes. 

    }
}

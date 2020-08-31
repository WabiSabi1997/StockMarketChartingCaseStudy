using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SectorMicroservice.Contexts
{
    public class SectorContext : DbContext
    {
        public SectorContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected SectorContext()
        {
        }

        public virtual DbSet<Sector> Sectors { get; set; }
        //public virtual DbSet<Company> Companies { get; set; }
        //public virtual DbSet<StockExchange> StockExchanges { get; set; }
        //public virtual DbSet<StockExchangeCompanies> StockExchangeCompanies { get; set; }


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
    }
}

﻿// <auto-generated />
using System;
using DataCreationMicroservice.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataCreationMicroservice.Migrations
{
    [DbContext(typeof(StockMarketContext))]
    partial class StockMarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockMarketCharting.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoardOfDirectors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorID")
                        .HasColumnType("int");

                    b.Property<double>("Turnover")
                        .HasColumnType("float");

                    b.HasKey("CompanyId");

                    b.HasIndex("SectorID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockMarketCharting.Models.IPODetail", b =>
                {
                    b.Property<int>("IPODetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OpenDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerShare")
                        .HasColumnType("float");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockExchangeCompanyCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("StockExchangeCompanyStockExchangeId")
                        .HasColumnType("int");

                    b.Property<int>("TotalNumOfShares")
                        .HasColumnType("int");

                    b.HasKey("IPODetailID");

                    b.HasIndex("StockExchangeCompanyStockExchangeId", "StockExchangeCompanyCompanyId");

                    b.ToTable("IPODetails");
                });

            modelBuilder.Entity("StockMarketCharting.Models.Sector", b =>
                {
                    b.Property<int>("SectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectorID");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("StockMarketCharting.Models.StockExchange", b =>
                {
                    b.Property<int>("StockExchangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockExchangeID");

                    b.ToTable("StockExchanges");
                });

            modelBuilder.Entity("StockMarketCharting.Models.StockExchangeCompany", b =>
                {
                    b.Property<int>("StockExchangeId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("StockExchangeId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("StockExchangeCompanies");
                });

            modelBuilder.Entity("StockMarketCharting.Models.StockPrice", b =>
                {
                    b.Property<int>("StockPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockExchangeId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockPriceId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("StockMarketCharting.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StockMarketCharting.Models.Company", b =>
                {
                    b.HasOne("StockMarketCharting.Models.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorID");
                });

            modelBuilder.Entity("StockMarketCharting.Models.IPODetail", b =>
                {
                    b.HasOne("StockMarketCharting.Models.StockExchangeCompany", "StockExchangeCompany")
                        .WithMany()
                        .HasForeignKey("StockExchangeCompanyStockExchangeId", "StockExchangeCompanyCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StockMarketCharting.Models.StockExchangeCompany", b =>
                {
                    b.HasOne("StockMarketCharting.Models.Company", "Company")
                        .WithMany("StockExchangeCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockMarketCharting.Models.StockExchange", "StockExchange")
                        .WithMany("StockExchangeCompanies")
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StockMarketCharting.Models.StockPrice", b =>
                {
                    b.HasOne("StockMarketCharting.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockMarketCharting.Models.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using DataCreationMicroservice.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SectorMicroservice.Repositories;
using StockMarketCharting.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Tests.Unit
{
    [TestFixture]
    public class UnitTestStockPriceRepo
    {
        DbContextOptions<StockMarketContext> options = new DbContextOptionsBuilder<StockMarketContext>()
        .UseInMemoryDatabase("StockMarketDB")
        .Options;
        StockMarketContext context = null;

        [SetUp]
        public void Setup()
        {
            context = new StockMarketContext(options);
            context.Sectors.AddRange(GetSectorList());
            context.SaveChanges();
        }

        private static List<Sector> GetSectorList()
        {
            return new List<Sector>()
                {
                    new Sector{SectorID=1, SectorName="Tech",
                        Brief = "Technology", Companies = new HashSet<Company>()},

                    new Sector{SectorID=2, SectorName="Finance",
                        Brief = "Financial Services", Companies = new HashSet<Company>()}
                };
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test_Get_Should_Return_Sectors()
        {
            //Arrange
            IRepository<Sector> repository = new SectorRepository(context);

            //Act
            var sectorList = repository.Get();

            //Assert
            var actualCount = sectorList.Count();
            Assert.That(GetSectorList().Count, Is.EqualTo(2), "List of students is not matching");
        }
    }
}
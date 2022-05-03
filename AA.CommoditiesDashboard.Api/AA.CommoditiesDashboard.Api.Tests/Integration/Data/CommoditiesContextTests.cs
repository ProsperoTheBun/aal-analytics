using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AA.CommoditiesDashboard.Api.Tests.Integration.Data
{

    [TestClass, TestCategory("Integration")]
    public class CommoditiesContextTests
    {
        [TestMethod]
        public async Task CommoditiesContext_returns_populated_tables()
        {
            // Arrange
            CommoditiesContext context = BuildContext();

            // Act
            var models = await context.TradingIndexModels.ToListAsync();
            var commodities = await context.Commodities.ToListAsync();
            var data = await context.CommodityData.ToListAsync();

            // Assert
            models.Should().NotBeNull();
            models.Should().NotBeEmpty();


            commodities.Should().NotBeNull();
            commodities.Should().NotBeEmpty();
            commodities[0].Model.Should().NotBeNull();

            data.Should().NotBeNull();
            data.Should().NotBeEmpty();
        }

        [TestMethod]
        public async Task Commodity_entity_contains_collection_data()
        {
            // Arrange
            CommoditiesContext context = BuildContext();

            // Act
            var commodity = await context.Commodities
                .Include(e => e.Model)
                .Include(e => e.Data)
                .FirstOrDefaultAsync();

            // Assert
            commodity.Model.Should().NotBeNull();
            commodity.Data.Should().NotBeNull();
            commodity.Data.Should().NotBeEmpty();
        }

        private static CommoditiesContext BuildContext()
        {
            return new CommoditiesContext(
                    new DbContextOptionsBuilder<CommoditiesContext>()
                    .UseSqlServer(Utilities.GetDevelopmentConnectionString())
                    .EnableSensitiveDataLogging()
                    .Options);
        }

    }
}

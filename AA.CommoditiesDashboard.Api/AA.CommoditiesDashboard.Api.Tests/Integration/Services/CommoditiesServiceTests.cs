using System.Linq;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Data;
using AA.CommoditiesDashboard.Api.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AA.CommoditiesDashboard.Api.Tests.Integration.Services
{
    [TestClass, TestCategory("Integration")]
    public class CommoditiesServiceTests
    {
        [TestMethod]
        public async Task GetHistoricalPnl_returns_data_from_database()
        {
            // Arrange
            var sut = GetSystemUnderTest();

            // Act
            var result = await sut.GetHistoricalPnl();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.First().Values.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetHistoricalPosition_returns_data_from_database()
        {
            // Arrange
            var sut = GetSystemUnderTest();

            // Act
            var result = await sut.GetHistoricalPosition();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.First().Values.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetCurrentForm_returns_data_from_database()
        {
            // Arrange
            var sut = GetSystemUnderTest();

            // Act
            var result = await sut.GetCurrentForm();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.First().Values.Should().NotBeNullOrEmpty();
        }

        private static CommoditiesContext BuildContext()
        {
            return new CommoditiesContext(
                    new DbContextOptionsBuilder<CommoditiesContext>()
                    .UseSqlServer(Utilities.GetDevelopmentConnectionString())
                    .EnableSensitiveDataLogging()
                    .Options);
        }

        private static CommoditiesService GetSystemUnderTest()
        {
            return new CommoditiesService(BuildContext());
        }
    }
}
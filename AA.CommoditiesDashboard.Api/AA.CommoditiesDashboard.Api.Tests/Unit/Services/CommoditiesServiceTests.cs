using System;
using System.Linq;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Data;
using AA.CommoditiesDashboard.Api.Model;
using AA.CommoditiesDashboard.Api.Services;
using AA.CommoditiesDashboard.Api.ViewModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Api.Tests.Unit.Services
{
    [TestClass, TestCategory("Unit")]
    public class CommoditiesServiceTests
    {
        private readonly DateTime baseDate = DateTime.Today;
        private readonly Mock<CommoditiesContext> mockContext = new Mock<CommoditiesContext>();

        [TestMethod]
        public void Ctor_null_parameter_throws()
        {
            // Act
            Action action = () => new CommoditiesService(null);

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>().WithParameterName("context");
        }

        [TestMethod]
        public async Task GetCurrentForm_groups_data_correctly()
        {
            // Arrange
            var sut = GetSystemUnderTest();
            var commodity1 = new Commodity
            {
                Id = 1,
                Name = "first",
                Model = new TradingIndexModel(),
            };
            var commodity2 = new Commodity
            {
                Id = 2,
                Name = "second",
                Model = new TradingIndexModel(),
            };

            var commodityData = new[]
            {
                new CommodityData { Commodity= commodity1, NewTradeAction = 3, Date = baseDate },
                new CommodityData { Commodity= commodity2, NewTradeAction = 4, Date = baseDate },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetCurrentForm();

            // Assert
            result.Should().HaveCount(2);
            result.Single(r => r.CommodityId == 1).Should().Match<CurrentForm>(cf => cf.CommodityName == "first" && cf.Values.Single() == 3);
            result.Single(r => r.CommodityId == 2).Should().Match<CurrentForm>(cf => cf.CommodityName == "second" && cf.Values.Single() == 4);
        }

        [TestMethod]
        public async Task GetCurrentForm_only_returns_five_recent_values()
        {
            // Arrange
            var sut = GetSystemUnderTest();

            var commodity = new Commodity
            {
                Id = 1,
                Name = "first",
                Model = new TradingIndexModel(),
            };

            var commodityData = new[]
            {
                new CommodityData { Commodity= commodity, NewTradeAction = 30, Date = baseDate.AddDays(3) },
                new CommodityData { Commodity= commodity, NewTradeAction = 70, Date = baseDate.AddDays(7) },
                new CommodityData { Commodity= commodity, NewTradeAction = 40, Date = baseDate.AddDays(4) },
                new CommodityData { Commodity= commodity, NewTradeAction = 50, Date = baseDate.AddDays(5) },
                new CommodityData { Commodity= commodity, NewTradeAction = 20, Date = baseDate.AddDays(2) },
                new CommodityData { Commodity= commodity, NewTradeAction = 60, Date = baseDate.AddDays(6) },
                new CommodityData { Commodity= commodity, NewTradeAction = 10, Date = baseDate.AddDays(1) },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetCurrentForm();

            // Assert
            result.Should().HaveCount(1);
            result.Single().Values.Should().HaveCount(5);
            result.Single().Values.Should().Equal(new[] { 70, 60, 50, 40, 30 });
        }

        [TestMethod]
        public async Task GetCurrentForm_orders_values_descending()
        {
            // Arrange
            var sut = GetSystemUnderTest();

            var commodity = new Commodity
            {
                Id = 1,
                Name = "first",
                Model = new TradingIndexModel(),
            };

            var commodityData = new[]
            {
                new CommodityData { Commodity= commodity, NewTradeAction = 10, Date = baseDate.AddDays(1) },
                new CommodityData { Commodity= commodity, NewTradeAction = 20, Date = baseDate.AddDays(2) },
                new CommodityData { Commodity= commodity, NewTradeAction = 30, Date = baseDate.AddDays(3) },
                new CommodityData { Commodity= commodity, NewTradeAction = 40, Date = baseDate.AddDays(4) },
                new CommodityData { Commodity= commodity, NewTradeAction = 50, Date = baseDate.AddDays(5) },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetCurrentForm();

            // Assert
            result.Should().HaveCount(1);
            result.Single().Values.Should().HaveCount(5);
            result.Single().Values.Should().Equal(new[] { 50, 40, 30, 20, 10 });
        }

        [TestMethod]
        public async Task GetHistoricalPnl_groups_data_correctly()
        {
            // Arrange
            var sut = GetSystemUnderTest();
            var commodity1 = new Commodity
            {
                Id = 1,
                Name = "first"
            };
            var commodity2 = new Commodity
            {
                Id = 2,
                Name = "second"
            };

            var commodityData = new[]
            {
                new CommodityData { Id = 100, Commodity= commodity1 },
                new CommodityData { Id = 200, Commodity= commodity2 },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetHistoricalPnl();

            // Assert
            result.Should().HaveCount(2);
            result.Single(r => r.CommodityId == 1).Name.Should().Be("first");
            result.Single(r => r.CommodityId == 2).Name.Should().Be("second");
        }

        [TestMethod]
        public async Task GetHistoricalPnl_orders_data_correctly()
        {
            // Arrange
            var sut = GetSystemUnderTest();
            var commodity1 = new Commodity
            {
                Id = 1
            };
            var commodity2 = new Commodity
            {
                Id = 2
            };

            var commodityData = new[]
            {
                new CommodityData { Id = 100, Commodity= commodity1, PnlDaily = 100M, Date = DateTime.Today.AddDays(10) },
                new CommodityData { Id = 200, Commodity= commodity1, PnlDaily = 200M, Date = DateTime.Today },
                new CommodityData { Id = 300, Commodity= commodity1, PnlDaily = 300M, Date = DateTime.Today.AddDays(-10) },
                new CommodityData { Id = 999, Commodity= commodity2, PnlDaily = 999M, Date = DateTime.Today },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetHistoricalPnl();

            // Assert
            result.Should().HaveCount(2);
            result.Single(r => r.CommodityId == 1).Values.ToList()
                .Should().HaveCount(3)
                .And.Subject.Should().BeInDescendingOrder();
        }

        [TestMethod]
        public async Task GetKeyMetrics_sums_year_to_date_pnl()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var commodity1 = new Commodity
            {
                Id = 1,
                Model = new TradingIndexModel()
            };
            var baseDate = new DateTime(2020, 7, 1);

            var commodityData = new[]
            {
                // only the first 3 values should be totalled
                new CommodityData { Id = 10, Commodity= commodity1, PnlDaily = 1M, Date = baseDate.AddDays(-1) },
                new CommodityData { Id = 20, Commodity= commodity1, PnlDaily = 10M, Date = baseDate.AddDays(-30) },
                new CommodityData { Id = 30, Commodity= commodity1, PnlDaily = 100M, Date = baseDate.AddDays(-50) },
                new CommodityData { Id = 40, Commodity= commodity1, PnlDaily = 1000M, Date = new DateTime(2019, 12, 31) },
                new CommodityData { Id = 50, Commodity= commodity1, PnlDaily = 10000M, Date = baseDate.AddDays(-400) },
            };

            mockContext.Setup(x => x.CommodityData).ReturnsDbSet(commodityData);

            // Act
            var result = await sut.GetKeyMetrics();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.Single().ProfitAndLossYearToDate.Should().Be(111);

        }

        private CommoditiesService GetSystemUnderTest()
        {
            return new CommoditiesService(mockContext.Object);
        }
    }
}
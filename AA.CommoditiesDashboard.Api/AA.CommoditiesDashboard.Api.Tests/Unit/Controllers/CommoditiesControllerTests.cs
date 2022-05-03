using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Controllers;
using AA.CommoditiesDashboard.Api.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AA.CommoditiesDashboard.Api.Tests.Unit.Controllers
{
    [TestClass, TestCategory("Unit")]
    public class CommoditiesControllerTests
    {
        private readonly Mock<ICommoditiesService> service = new Mock<ICommoditiesService>();

        [TestMethod]
        public void Ctor_null_parameter_throws()
        {
            // Act
            Action action = () => new CommoditiesController(null);

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>().WithParameterName("commoditiesService");
        }

        [TestMethod]
        public async Task GetKeyMetricsAsync_method_calls_service_method()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            _ = await sut.GetKeyMetricsAsync();

            // Assert
            service.Verify(x => x.GetKeyMetrics(), Times.Once);
        }

        [TestMethod]
        public async Task GetHistoricalPositionAsync_method_calls_service_method()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            _ = await sut.GetHistoricalPositionAsync();

            // Assert
            service.Verify(x => x.GetHistoricalPosition(), Times.Once);
        }

        [TestMethod]
        public async Task GetHistoricalProfitAndLossAsync_method_calls_service_method()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            _ = await sut.GetHistoricalProfitAndLossAsync();

            // Assert
            service.Verify(x => x.GetHistoricalPnl(), Times.Once);
        }

        [TestMethod]
        public async Task GetCurrentFromAsync_method_calls_service_method()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();

            // Act
            _ = await sut.GetCurrentFormAsync();

            // Assert
            service.Verify(x => x.GetCurrentForm(), Times.Once);
        }

        private CommoditiesController GetSystemUnderTest()
        {
            return new CommoditiesController(service.Object);
        }
    }
}

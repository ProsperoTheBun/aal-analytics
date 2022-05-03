using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Services;
using AA.CommoditiesDashboard.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    [ApiController]
    public class CommoditiesController
    {
        private readonly ICommoditiesService commoditiesService;

        public CommoditiesController(ICommoditiesService commoditiesService)
        {
            this.commoditiesService = commoditiesService ?? throw new ArgumentNullException(nameof(commoditiesService));
        }

        [HttpGet]
        [Route("keymetrics")]
        public async Task<IActionResult> GetKeyMetricsAsync()
        {
            var result = await this.commoditiesService.GetKeyMetrics();
            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("historicalpnl")]
        public async Task<IActionResult> GetHistoricalProfitAndLossAsync()
        {
            var result = await this.commoditiesService.GetHistoricalPnl();
            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("historicalposition")]
        public async Task<IActionResult> GetHistoricalPositionAsync()
        {
            var result = await this.commoditiesService.GetHistoricalPosition();
            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("currentform")]
        public async Task<IEnumerable<CurrentForm>> GetCurrentFormAsync()
        {
            var result = await this.commoditiesService.GetCurrentForm();
            return result;
        }
    }
}
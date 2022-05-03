using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Data;
using AA.CommoditiesDashboard.Api.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Api.Services
{
    /// <summary>
    /// Service to collect commodities results.
    /// </summary>
    /// <seealso cref="AA.CommoditiesDashboard.Api.Services.ICommoditiesService" />
    public class CommoditiesService : ICommoditiesService
    {
        private readonly CommoditiesContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommoditiesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public CommoditiesService(CommoditiesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets the current form.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CurrentForm>> GetCurrentForm()
        {
            var datesQuery = context.CommodityData.Select(r => r.Date).Distinct().OrderByDescending(r => r).Take(5);

            var values = await context.CommodityData
                .Include(cd => cd.Commodity)
                    .ThenInclude(c => c.Model)
                .Join(datesQuery, cd => cd.Date, d => d, (cd, d) => cd)
                .OrderByDescending(cd => cd.Date)
                .ToListAsync();

            var list = values.GroupBy(r => r.Commodity.Id)
              .Select(g =>
              {
                  var firstInGroup = g.First();
                  return new CurrentForm
                  {
                      CommodityId = firstInGroup.Commodity.Id,
                      CommodityName = firstInGroup.Commodity.Name,
                      ModelId = firstInGroup.Commodity.Model.Id,
                      ModelName = firstInGroup.Commodity.Model.Name,
                      Values = g.Select(i => i.NewTradeAction),
                  };
              })
              .ToList();

            return list;
        }

        /// <summary>
        /// Gets the historical PNL.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HistoricalMetric>> GetHistoricalPnl()
        {
            var values = await context.CommodityData
                .Include(cd => cd.Commodity)
                .OrderBy(cd => cd.Date)
                .ToListAsync();

            var result = values.GroupBy(v => v.Commodity)
                .Select(g => new HistoricalMetric
                {
                    CommodityId = g.Key.Id,
                    Name = g.Key.Name,
                    Values = g.Select(v => v.PnlDaily)
                });

            return result;
        }

        /// <summary>
        /// Gets the historical position.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HistoricalMetric>> GetHistoricalPosition()
        {
            var values = await context.CommodityData
                .Include(cd => cd.Commodity)
                .OrderBy(cd => cd.Date)
                .ToListAsync();

            var result = values.GroupBy(v => v.Commodity)
                .Select(g => new HistoricalMetric
                {
                    CommodityId = g.Key.Id,
                    Name = g.Key.Name,
                    Values = g.Select(v => (decimal)v.Position)
                });

            return result;
        }

        /// <summary>
        /// Gets the key metrics.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<KeyMetric>> GetKeyMetrics()
        {
            var currentDate = DateTime.Today;

            // data is older than one year so compensate by using the most recent date in the database
            currentDate = context.CommodityData.Max(cd => cd.Date);

            var values = await context.CommodityData
                .Include(d => d.Commodity)
                    .ThenInclude(c => c.Model)
                .Where(d => d.Date.Year >= currentDate.Year)
                .OrderByDescending(d => d.Date)
                .ToListAsync();

            return values.GroupBy(v => v.Commodity)
                .Select(g =>
                {
                    var firstInGroup = g.FirstOrDefault();
                    return new KeyMetric
                    {
                        CommodityId = firstInGroup.Commodity.Id,
                        Date = firstInGroup.Date,
                        Name = firstInGroup.Commodity.Name,
                        Model = firstInGroup.Commodity.Model.Name,
                        ProfitAndLoss = firstInGroup.PnlDaily,
                        ProfitAndLossYearToDate = g.Sum(d => d.PnlDaily),
                    };
                });
        }
    }
}
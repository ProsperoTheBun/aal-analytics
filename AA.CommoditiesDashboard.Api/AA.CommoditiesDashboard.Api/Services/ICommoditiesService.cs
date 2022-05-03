using System.Collections.Generic;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.ViewModel;

namespace AA.CommoditiesDashboard.Api.Services
{
    /// <summary>
    /// Service to collect commodities results.
    /// </summary>
    public interface ICommoditiesService
    {
        /// <summary>
        /// Gets the key metrics.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<KeyMetric>> GetKeyMetrics();

        /// <summary>
        /// Gets the historical PNL.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HistoricalMetric>> GetHistoricalPnl();

        /// <summary>
        /// Gets the current form.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CurrentForm>> GetCurrentForm();

        /// <summary>
        /// Gets the historical position.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HistoricalMetric>> GetHistoricalPosition();
    }
}
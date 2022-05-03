using AA.CommoditiesDashboard.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Api.Data
{
    /// <summary>
    /// Data access context for Commodities Database
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CommoditiesContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommoditiesContext"/> class.
        /// </summary>
        /// <remarks>
        /// Parameterless constructor required for mocking.
        /// </remarks>
        public CommoditiesContext()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommoditiesContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CommoditiesContext(DbContextOptions<CommoditiesContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the commodities.
        /// </summary>
        public virtual DbSet<Commodity> Commodities { get; set; }

        /// <summary>
        /// Gets or sets the commodity data.
        /// </summary>
        public virtual DbSet<CommodityData> CommodityData { get; set; }

        /// <summary>
        /// Gets or sets the trading index models.
        /// </summary>
        public virtual DbSet<TradingIndexModel> TradingIndexModels { get; set; }
    }
}
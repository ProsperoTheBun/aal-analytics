using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Api.ViewModel
{
    public class HistoricalMetric
    {
        public int CommodityId { get; set; }

        public string Name { get; set; }

        public IEnumerable<decimal> Values { get; set; }
    }
}
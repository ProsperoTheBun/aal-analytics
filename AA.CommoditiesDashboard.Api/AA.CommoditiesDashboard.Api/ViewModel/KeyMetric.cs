using System;

namespace AA.CommoditiesDashboard.Api.ViewModel
{
    public class KeyMetric
    {
        public int CommodityId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Model { get; set; }

        public decimal ProfitAndLoss { get; set; }

        public decimal ProfitAndLossYearToDate { get; set; }
    }
}

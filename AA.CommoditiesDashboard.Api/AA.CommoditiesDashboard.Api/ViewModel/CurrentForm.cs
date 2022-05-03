using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Api.ViewModel
{
    public class CurrentForm
    {
        public int CommodityId { get; set; }

        public string CommodityName { get; set; }

        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public IEnumerable<int> Values { get; set; }
    }
}
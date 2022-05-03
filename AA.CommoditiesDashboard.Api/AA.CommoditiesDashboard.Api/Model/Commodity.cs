using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.Api.Model
{
    [Table("Commodity")]
    public class Commodity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TradingIndexModel Model { get; set; }

        public List<CommodityData> Data { get; }  = new List<CommodityData>();
    }
}
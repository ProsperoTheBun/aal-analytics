using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.Api.Model
{
    [Table("Model")]
    public class TradingIndexModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

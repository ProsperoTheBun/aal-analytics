using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.Api.Model
{
    [Table("CommodityData")]
    public class CommodityData
    {
        public Commodity Commodity { get; set; }

        public string Contract { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public int NewTradeAction { get; set; }

        public decimal PnlDaily { get; set; }

        public int Position { get; set; }

        public decimal Price { get; set; }
    }
}
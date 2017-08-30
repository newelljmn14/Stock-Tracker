using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTracker.DataAccess
{
    public class Stock
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(8)]
        public string StockName { get; set; }
        public decimal InitialPrice { get; set; }
    }
}
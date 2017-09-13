using System.Data.Entity;

namespace StockTracker.DataAccess
{
    public class StockTrackerContext : DbContext
    {
        public StockTrackerContext() : base("name=stockTrackerConnectionHome")
        {

        }

        public DbSet<UserTrackedStock> UserTrackedStocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}

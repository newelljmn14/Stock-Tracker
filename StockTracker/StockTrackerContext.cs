using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker
{
    class StockTrackerContext : DbContext
    {
        public StockTrackerContext() : base("name=stockTrackerConnection")
        {

        }

        public DbSet<UserTrackedStock> UserTrackedStocks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

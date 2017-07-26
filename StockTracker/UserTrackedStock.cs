using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker
{
    public class UserTrackedStock : Stock, IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }

        public DateTime? DateTimeTracked { get; set; }

        public UserTrackedStock(string stockName, User user) : base(stockName)
        {
            this.User = user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker
{
    public class UserTrackedStock
    {
        public UserTrackedStock()
        {

        }

        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public int Id { get; set; }
        public User User { get; set; }

        public DateTime? DateTracked { get; set; }

    }
}

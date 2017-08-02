using System;
using System.Linq;
using NUnit.Framework;

namespace StockTracker.DataAccess.Tests
{
    public class UserTrackedStock_should_
    {
        [SetUp]
        public void SetUp()
        {
            var userTrackedStock1 = new UserTrackedStock
            {
                DateTracked = DateTime.Now,
                InitialPrice = 50,
                Name = "setup_NKE"
            };
            var userTrackedStock2 = new UserTrackedStock
            {
                DateTracked = DateTime.Now,
                InitialPrice = 20,
                Name = "setup_AAPL"
            };

            using (var ctx = new StockTrackerContext())
            {
                ctx.UserTrackedStocks.Add(userTrackedStock1);
                ctx.UserTrackedStocks.Add(userTrackedStock2);

                ctx.SaveChanges();
            }
        }

        [Test]
        public void populate_from_model()
        {
            using (var ctx = new StockTrackerContext())
            {
                var userTrackedStocks = ctx.UserTrackedStocks.ToList();

                Assert.IsNotNull(userTrackedStocks);
            }
        }

        [Test]
        public void update()
        {
            var newName = "someName";
            var newDate = DateTime.Now.AddDays(1);
            var newInitPrice = 100;

            using (var ctx = new StockTrackerContext())
            {
                var stockToChange = ctx.UserTrackedStocks.First();

                stockToChange.Name = newName;
                stockToChange.DateTracked = newDate;
                stockToChange.InitialPrice = newInitPrice;

                ctx.SaveChanges();
            }

            using (var ctx = new StockTrackerContext())
            {
                var changedStock = ctx.UserTrackedStocks.First();

                Assert.AreEqual(changedStock.Name, newName);
                Assert.AreEqual(changedStock.DateTracked.Value.Year, newDate.Year);
                Assert.AreEqual(changedStock.InitialPrice, newInitPrice);
            }

        }

        [TearDown]
        public void TearDown()
        {
            using (var ctx = new StockTrackerContext())
            {
                var userStocksToDelete = ctx.UserTrackedStocks.Where(x => x.Name.StartsWith("setup_"));
                ctx.UserTrackedStocks.RemoveRange(userStocksToDelete);
            }
        }
    }
}

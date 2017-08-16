using System.Linq;
using NUnit.Framework;
using StockTracker.DataAccess;

namespace StockTracker.Tests
{
    [TestFixture]
    public class StockController_should_
    {
        [OneTimeSetUp]
        public void SetupEnvironment()
        {
            using (var context = new StockTrackerContext())
            {
                Stock StockToAdd = new Stock
                {
                    Id = 1,
                    StockName = "TST"
                };

                context.Stocks.Add(StockToAdd);
                context.SaveChanges();
            }

        }

        [OneTimeTearDown]
        public void TeardownEnvironment()
        {
            using (var context = new StockTrackerContext())
            {
                Stock StockToDelete = context.Stocks.FirstOrDefault(s => s.StockName == "TST");

                context.Stocks.Remove(StockToDelete);
                context.SaveChanges();
            }
        }

        [Test]
        public void should_get_a_stock_from_database_with_id_1()
        {
            //string stocksUrl = "http://localhost:22447/api/stock/1";
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = client.GetAsync(stocksUrl).Result;

            //Assert.AreEqual(response, 0);
        }
    }
}

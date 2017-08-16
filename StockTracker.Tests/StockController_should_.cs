using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using StockTracker.DataAccess;
using StockTracker.Server.Controllers;

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
            using (var context = new StockTrackerContext())
            {
                var expectedStock = context.Stocks.First();
                var stockController = new StockController();
                var actualStock = stockController.Get(expectedStock.Id)[0];

                expectedStock.ShouldBeEquivalentTo(actualStock);
            }

            
        }
    }
}

using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using StockTracker.DataAccess;
using StockTracker.Server.Controllers;
using StockTracker.Server.Views;

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

        [Test]
        public void should_post_a_stock()
        {
            using (var context = new StockTrackerContext())
            {
                var expectedStock = new StockView
                {
                    Id = 2,
                    Name = "Second"
                };

                var stockController = new StockController();
                stockController.Post(expectedStock);

                var actualStock = context.Stocks.FirstOrDefault(s => s.StockName == "Second");
                context.Stocks.Remove(actualStock);
                context.SaveChanges();

                expectedStock.ShouldBeEquivalentTo(actualStock);
            }
        }

        [Test]
        public void should_delete_a_stock()
        {
            using (var context = new StockTrackerContext())
            {
                var expectedStock = new Stock
                {
                    Id = 2,
                   StockName  = "Delete"
                };
                context.Stocks.Add(expectedStock);
                context.SaveChanges();

                var stockController = new StockController();
                stockController.Delete(expectedStock.Id);

                var actualStock = context.Stocks.FirstOrDefault(s => s.StockName == "Delete");

                Assert.IsNull(actualStock);

                //context.Stocks.Remove(actualStock);
                //context.SaveChanges();
            }
        }

    }
}

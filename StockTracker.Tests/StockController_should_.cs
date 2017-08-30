using System.Linq;
using System.Transactions;
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
        private TransactionScope _transactionScope;
        private string _testName = "whatever";

        [SetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            _transactionScope.Dispose();
        }

        [Test]
        public void get_a_stock_from_database_with_id_1()
        {
            using (var context = new StockTrackerContext())
            {
                var expectedStock = new Stock
                {
                    StockName = _testName,
                };

                context.Stocks.Add(expectedStock);
                context.SaveChanges();

                var stockController = new StockController();
                var actualStock = stockController.Get(expectedStock.Id)[0];

                Assert.AreEqual(expectedStock.StockName, actualStock.Name);
            }
            
        }

        [Test]
        public void post_a_stock()
        {
            using (var context = new StockTrackerContext())
            {
                var expectedStockView = new StockView
                {
                    Name = _testName
                };

                var stockController = new StockController();
                stockController.Post(expectedStockView);

                Assert.IsTrue(context.Stocks.Any(s => s.StockName == _testName));
            }
        }

        [Test]
        public void should_delete_a_stock()
        {
            using (var context = new StockTrackerContext())
            {
                var expectedStock = new Stock
                {
                   StockName  = _testName
                };
                context.Stocks.Add(expectedStock);
                context.SaveChanges();

                var stockController = new StockController();
                stockController.Delete(expectedStock.Id);

                var actualStock = context.Stocks.FirstOrDefault(s => s.StockName == _testName);

                Assert.IsNull(actualStock);

            }
        }

    }
}

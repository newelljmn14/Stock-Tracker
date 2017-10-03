using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StockTracker.Server.Views;
using StockTracker.DataAccess;

namespace StockTracker.Server.Controllers
{
    [Authorize]
    public class StockController : ApiController
    {
        public List<StockView> Get(int id = 0)
        {

            using (var ctx = new StockTrackerContext())
            {
                if (id != 0)
                {
                    return ctx.Stocks
                        .Where(s => s.Id == id)
                        .Select(s => new StockView
                        {
                            Id = s.Id,
                            Name = s.StockName
                        })
                        .ToList();
                }
                return ctx.Stocks
                    .Select(s => new StockView
                    {
                        Id = s.Id,
                        Name = s.StockName
                    })
                    .ToList();

            }
        }

        public int Post(StockView stockView)
        {
            using (var ctx = new StockTrackerContext())
            {
                var stockToCreate = new Stock
                {
                    StockName = stockView.Name,
                };
                ctx.Stocks.Add(stockToCreate);
                ctx.SaveChanges();
                return stockToCreate.Id;
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new StockTrackerContext())
            {
                var stockToDelete = ctx.Stocks.FirstOrDefault(s => s.Id == id);

                if (stockToDelete == null)
                {
                    throw new Exception("Stock not found");
                }

                ctx.Stocks.Remove(stockToDelete);
                ctx.SaveChanges();
            }
        }

        public void Update(int id, StockView stockView)
        {
            using (var context = new StockTrackerContext())
            {
                var stockToUpdate = context.Stocks.FirstOrDefault(s => s.Id == id);
                stockToUpdate.StockName = stockView.Name;
                context.SaveChanges();
            }
        }
    }
}

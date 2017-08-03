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
    public class StockController : ApiController
    {
        public StockView Get(int id = 0)
        {
            var stockView = new StockView();
            
            using (var context = new StockTrackerContext())
            {
                context.Stocks.Add(new Stock("NKE"));
                var returnedStock = context.Stocks.FirstOrDefault(s => s.StockName == "NKE");
                stockView.Name = returnedStock.StockName;
            }

            return stockView;
        }
    }
}

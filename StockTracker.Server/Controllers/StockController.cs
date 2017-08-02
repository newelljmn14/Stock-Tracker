using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StockTracker.Server.Views;

namespace StockTracker.Server.Controllers
{
    public class StockController : ApiController
    {
        public StockView Get(int id = 0)
        {
            return new StockView
            {
                Id = 1,
                Name = "Foobar"
            };

        }
    }
}

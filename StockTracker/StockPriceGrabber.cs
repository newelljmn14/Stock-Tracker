using System;
using System.Linq;
using HtmlAgilityPack;

namespace StockTracker.DataAccess
{
    public class StockPriceGrabber
    {
        public static decimal Grab(string stockName)
        {
            HtmlWeb web = new HtmlWeb();
            string queryUrl = String.Format("https://finance.yahoo.com/quote/{0}?p={0}", stockName);
            HtmlDocument document = web.Load(queryUrl);
            HtmlNode rootNode = document.DocumentNode;

            string stockPriceXPath = "//*[@id='quote-header-info']/div[3]/div[1]/div/span[1]";

            decimal currentStockPrice = 0;

            try
            {
                string currentStockPriceStr = rootNode.SelectNodes(stockPriceXPath).FirstOrDefault().InnerHtml;
                currentStockPrice = Decimal.Parse(currentStockPriceStr);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Please enter a valid stock symbol");
            }

            return currentStockPrice;
        }
    }
}


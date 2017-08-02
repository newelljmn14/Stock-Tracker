namespace StockTracker.DataAccess
{
    public class Stock
    {
        public string StockName { get; set; }
        public decimal InitialPrice { get; set; }

        public Stock(string name)
        {
            this.StockName = name;
            this.InitialPrice = StockPriceGrabber.Grab(name);
        }
    }
}
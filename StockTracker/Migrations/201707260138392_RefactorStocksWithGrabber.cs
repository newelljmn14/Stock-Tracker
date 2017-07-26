namespace StockTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorStocksWithGrabber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserTrackedStocks", "InitialPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTrackedStocks", "InitialPrice", c => c.Double(nullable: false));
        }
    }
}

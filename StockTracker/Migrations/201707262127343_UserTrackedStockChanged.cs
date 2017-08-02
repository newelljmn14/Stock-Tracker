using System.Data.Entity.Migrations;

namespace StockTracker.DataAccess.Migrations
{
    public partial class UserTrackedStockChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTrackedStocks", "Name", c => c.String());
            AddColumn("dbo.UserTrackedStocks", "DateTracked", c => c.DateTime());
            DropColumn("dbo.UserTrackedStocks", "DateTimeTracked");
            DropColumn("dbo.UserTrackedStocks", "StockName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTrackedStocks", "StockName", c => c.String());
            AddColumn("dbo.UserTrackedStocks", "DateTimeTracked", c => c.DateTime());
            DropColumn("dbo.UserTrackedStocks", "DateTracked");
            DropColumn("dbo.UserTrackedStocks", "Name");
        }
    }
}

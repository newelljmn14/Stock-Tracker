namespace StockTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStockNumberCharacters : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Stocks", new[] { "StockName" });
            AlterColumn("dbo.Stocks", "StockName", c => c.String(maxLength: 24));
            CreateIndex("dbo.Stocks", "StockName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Stocks", new[] { "StockName" });
            AlterColumn("dbo.Stocks", "StockName", c => c.String(maxLength: 8));
            CreateIndex("dbo.Stocks", "StockName", unique: true);
        }
    }
}

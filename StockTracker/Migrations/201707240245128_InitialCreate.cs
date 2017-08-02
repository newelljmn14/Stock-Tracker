using System.Data.Entity.Migrations;

namespace StockTracker.DataAccess.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTrackedStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(),
                        InitialPrice = c.Double(nullable: false),
                        DateTimeTracked = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTrackedStocks", "User_Id", "dbo.Users");
            DropIndex("dbo.UserTrackedStocks", new[] { "User_Id" });
            DropTable("dbo.UserTrackedStocks");
            DropTable("dbo.Users");
        }
    }
}

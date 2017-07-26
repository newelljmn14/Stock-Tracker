namespace StockTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropEmailAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "EmailAddress");
        }
    }
}

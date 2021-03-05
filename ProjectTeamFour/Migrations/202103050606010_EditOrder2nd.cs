namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder2nd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderName", c => c.String());
            AddColumn("dbo.Orders", "OrderAddress", c => c.String());
            AddColumn("dbo.Orders", "OrderPhone", c => c.String());
            AddColumn("dbo.Orders", "OrderConEmail", c => c.String());
            AddColumn("dbo.Orders", "OrderTotalAccount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TradeNo", c => c.String());
            AddColumn("dbo.Orders", "RtnCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RtnCode");
            DropColumn("dbo.Orders", "TradeNo");
            DropColumn("dbo.Orders", "OrderTotalAccount");
            DropColumn("dbo.Orders", "OrderConEmail");
            DropColumn("dbo.Orders", "OrderPhone");
            DropColumn("dbo.Orders", "OrderAddress");
            DropColumn("dbo.Orders", "OrderName");
        }
    }
}

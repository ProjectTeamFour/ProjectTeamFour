namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class od新增欄位 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "PlanShipDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "PlanShipDate");
        }
    }
}

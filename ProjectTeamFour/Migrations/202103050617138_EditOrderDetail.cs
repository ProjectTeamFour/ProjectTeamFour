namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans");
            DropIndex("dbo.OrderDetails", new[] { "Plan_PlanId" });
            RenameColumn(table: "dbo.OrderDetails", name: "Plan_PlanId", newName: "PlanId");
            AddColumn("dbo.OrderDetails", "PlanTitle", c => c.String());
            AddColumn("dbo.OrderDetails", "OrderQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "PlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "PlanId");
            AddForeignKey("dbo.OrderDetails", "PlanId", "dbo.Plans", "PlanId", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "OrderAddress");
            DropColumn("dbo.OrderDetails", "OrderPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "OrderPhone", c => c.String());
            AddColumn("dbo.OrderDetails", "OrderAddress", c => c.String());
            DropForeignKey("dbo.OrderDetails", "PlanId", "dbo.Plans");
            DropIndex("dbo.OrderDetails", new[] { "PlanId" });
            AlterColumn("dbo.OrderDetails", "PlanId", c => c.Int());
            DropColumn("dbo.OrderDetails", "OrderPrice");
            DropColumn("dbo.OrderDetails", "OrderQuantity");
            DropColumn("dbo.OrderDetails", "PlanTitle");
            RenameColumn(table: "dbo.OrderDetails", name: "PlanId", newName: "Plan_PlanId");
            CreateIndex("dbo.OrderDetails", "Plan_PlanId");
            AddForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans", "PlanId");
        }
    }
}

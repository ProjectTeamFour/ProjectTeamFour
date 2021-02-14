namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimizationDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderDetailPlanId", "dbo.Plans");
            DropIndex("dbo.OrderDetails", new[] { "OrderDetailPlanId" });
            DropIndex("dbo.Plans", new[] { "Projectid" });
            RenameColumn(table: "dbo.Orders", name: "OrderMemberId", newName: "MemberId");
            RenameColumn(table: "dbo.OrderDetails", name: "OrderDetailPlanId", newName: "Plan_PlanId");
            RenameIndex(table: "dbo.Orders", name: "IX_OrderMemberId", newName: "IX_MemberId");
            AddColumn("dbo.Orders", "ProjectId", c => c.Guid(nullable: false));
            AddColumn("dbo.Orders", "PlanId", c => c.Guid(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderAddress", c => c.String());
            AddColumn("dbo.OrderDetails", "OrderPhone", c => c.String());
            AddColumn("dbo.Plans", "ProjectPlanId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "MemberId", c => c.String());
            AlterColumn("dbo.OrderDetails", "Plan_PlanId", c => c.Guid());
            CreateIndex("dbo.OrderDetails", "Plan_PlanId");
            CreateIndex("dbo.Plans", "ProjectId");
            AddForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans", "PlanId");
            DropColumn("dbo.Orders", "OrderAddress");
            DropColumn("dbo.Orders", "OrderPhone");
            DropColumn("dbo.Plans", "OderIndex");
            DropColumn("dbo.Projects", "CreatorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "CreatorName", c => c.String());
            AddColumn("dbo.Plans", "OderIndex", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderPhone", c => c.String());
            AddColumn("dbo.Orders", "OrderAddress", c => c.String());
            DropForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans");
            DropIndex("dbo.Plans", new[] { "ProjectId" });
            DropIndex("dbo.OrderDetails", new[] { "Plan_PlanId" });
            AlterColumn("dbo.OrderDetails", "Plan_PlanId", c => c.Guid(nullable: false));
            DropColumn("dbo.Projects", "MemberId");
            DropColumn("dbo.Plans", "ProjectPlanId");
            DropColumn("dbo.OrderDetails", "OrderPhone");
            DropColumn("dbo.OrderDetails", "OrderAddress");
            DropColumn("dbo.Orders", "PlanId");
            DropColumn("dbo.Orders", "ProjectId");
            RenameIndex(table: "dbo.Orders", name: "IX_MemberId", newName: "IX_OrderMemberId");
            RenameColumn(table: "dbo.OrderDetails", name: "Plan_PlanId", newName: "OrderDetailPlanId");
            RenameColumn(table: "dbo.Orders", name: "MemberId", newName: "OrderMemberId");
            CreateIndex("dbo.Plans", "Projectid");
            CreateIndex("dbo.OrderDetails", "OrderDetailPlanId");
            AddForeignKey("dbo.OrderDetails", "OrderDetailPlanId", "dbo.Plans", "PlanId", cascadeDelete: true);
        }
    }
}

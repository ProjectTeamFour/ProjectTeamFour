namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "PlanId", "dbo.Plans");
            DropIndex("dbo.Orders", new[] { "PlanId" });
            RenameColumn(table: "dbo.Orders", name: "PlanId", newName: "Plan_PlanId");
            AlterColumn("dbo.Orders", "Plan_PlanId", c => c.Int());
            CreateIndex("dbo.Orders", "Plan_PlanId");
            AddForeignKey("dbo.Orders", "Plan_PlanId", "dbo.Plans", "PlanId");
            DropColumn("dbo.Orders", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ProjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "Plan_PlanId", "dbo.Plans");
            DropIndex("dbo.Orders", new[] { "Plan_PlanId" });
            AlterColumn("dbo.Orders", "Plan_PlanId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "Plan_PlanId", newName: "PlanId");
            CreateIndex("dbo.Orders", "PlanId");
            AddForeignKey("dbo.Orders", "PlanId", "dbo.Plans", "PlanId", cascadeDelete: true);
        }
    }
}

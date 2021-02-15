namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimization4ndDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Orders", "MemberId", "dbo.Members");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Plans", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropIndex("dbo.Orders", new[] { "MemberId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "Plan_PlanId" });
            DropIndex("dbo.Plans", new[] { "ProjectId" });
            DropPrimaryKey("dbo.Comments");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Plans");
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "MemberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "MemberId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "MemberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PlanId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderDetailId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Plan_PlanId", c => c.Int());
            AlterColumn("dbo.Plans", "PlanId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Plans", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "MemberId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Comments", "CommentId");
            AddPrimaryKey("dbo.Members", "MemberId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.OrderDetails", "OrderDetailId");
            AddPrimaryKey("dbo.Plans", "PlanId");
            AddPrimaryKey("dbo.Projects", "ProjectId");
            CreateIndex("dbo.Comments", "ProjectId");
            CreateIndex("dbo.Comments", "MemberId");
            CreateIndex("dbo.Orders", "MemberId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.OrderDetails", "Plan_PlanId");
            CreateIndex("dbo.Plans", "ProjectId");
            AddForeignKey("dbo.Comments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans", "PlanId");
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Plans", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropIndex("dbo.Plans", new[] { "ProjectId" });
            DropIndex("dbo.OrderDetails", new[] { "Plan_PlanId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropPrimaryKey("dbo.Projects");
            DropPrimaryKey("dbo.Plans");
            DropPrimaryKey("dbo.OrderDetails");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Projects", "MemberId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Plans", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Plans", "PlanId", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderDetails", "Plan_PlanId", c => c.Guid());
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderDetailId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "PlanId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "MemberId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Orders", "OrderId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Members", "MemberId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comments", "MemberId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comments", "ProjectId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comments", "CommentId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Projects", "ProjectId");
            AddPrimaryKey("dbo.Plans", "PlanId");
            AddPrimaryKey("dbo.OrderDetails", "OrderDetailId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Members", "MemberId");
            AddPrimaryKey("dbo.Comments", "CommentId");
            CreateIndex("dbo.Plans", "ProjectId");
            CreateIndex("dbo.OrderDetails", "Plan_PlanId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Orders", "MemberId");
            CreateIndex("dbo.Comments", "MemberId");
            CreateIndex("dbo.Comments", "ProjectId");
            AddForeignKey("dbo.Plans", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans", "PlanId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
    }
}

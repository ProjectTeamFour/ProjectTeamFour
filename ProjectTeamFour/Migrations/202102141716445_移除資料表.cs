namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 移除資料表 : DbMigration
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
            DropTable("dbo.Comments");
            DropTable("dbo.Members");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Plans");
            DropTable("dbo.Projects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        ProjectName = c.String(),
                        FundingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountThreshold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        ProjectStatus = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatorName = c.String(),
                        Fundedpeople = c.Int(nullable: false),
                        ProjectDescription = c.String(),
                        ProjectImgUrl = c.String(),
                        ProjectVideoUrl = c.String(),
                        Project_Question = c.String(),
                        Project_Answer = c.String(),
                        ProjectPlansCount = c.Int(nullable: false),
                        ProjectCoverUrl = c.String(),
                        ProjectMainUrl = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Guid(nullable: false),
                        ProjectPlanId = c.Int(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        PlanTitle = c.String(),
                        PlanFundedPeople = c.Int(nullable: false),
                        PlanShipDate = c.DateTime(nullable: false),
                        PlanDescription = c.String(),
                        PlanImgUrl = c.String(),
                        PlanePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Guid(nullable: false),
                        OrderDetailDes = c.String(),
                        OrderId = c.Guid(nullable: false),
                        OrderAddress = c.String(),
                        OrderPhone = c.String(),
                        Plan_PlanId = c.Guid(),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Guid(nullable: false),
                        MemberName = c.String(),
                        MemberTeamName = c.String(),
                        MemberAccount = c.String(),
                        MemberPassword = c.String(),
                        MemberAddress = c.String(),
                        MemberPhone = c.String(),
                        MemberRegEmail = c.String(),
                        MemberConEmail = c.String(),
                        Gender = c.String(),
                        MemberBirth = c.DateTime(nullable: false),
                        AboutMe = c.String(),
                        ProfileImgUrl = c.String(),
                        MemberWebsite = c.String(),
                        MemberMessage = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        Comment_Question = c.String(),
                        Comment_Time = c.DateTime(nullable: false),
                        Comment_Answer = c.String(),
                    })
                .PrimaryKey(t => t.CommentId);
            
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

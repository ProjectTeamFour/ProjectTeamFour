namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 將guid改成int : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        Comment_Question = c.String(),
                        Comment_Time = c.DateTime(nullable: false),
                        Comment_Answer = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
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
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderDetailDes = c.String(),
                        OrderId = c.Int(nullable: false),
                        OrderAddress = c.String(),
                        OrderPhone = c.String(),
                        Plan_PlanId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.Plan_PlanId)
                .Index(t => t.OrderId)
                .Index(t => t.Plan_PlanId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        ProjectPlanId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        PlanTitle = c.String(),
                        PlanFundedPeople = c.Int(nullable: false),
                        PlanShipDate = c.DateTime(nullable: false),
                        PlanDescription = c.String(),
                        PlanImgUrl = c.String(),
                        PlanePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        FundingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        ProjectStatus = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MemberId = c.String(),
                        Fundedpeople = c.Int(nullable: false),
                        ProjectDescription = c.String(),
                        ProjectVideoUrl = c.String(),
                        Project_Question = c.String(),
                        Project_Answer = c.String(),
                        ProjectPlansCount = c.Int(nullable: false),
                        ProjectCoverUrl = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Plan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.Plans", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Orders", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropIndex("dbo.Plans", new[] { "ProjectId" });
            DropIndex("dbo.OrderDetails", new[] { "Plan_PlanId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "PlanId" });
            DropIndex("dbo.Orders", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Plans");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Members");
            DropTable("dbo.Comments");
        }
    }
}

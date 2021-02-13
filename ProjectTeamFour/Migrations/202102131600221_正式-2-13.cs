namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 正式213 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.MemberId);
            
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
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        OrderMemberId = c.Guid(nullable: false),
                        OrderAddress = c.String(),
                        OrderPhone = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Members", t => t.OrderMemberId, cascadeDelete: true)
                .Index(t => t.OrderMemberId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Guid(nullable: false),
                        OrderDetailDes = c.String(),
                        OrderId = c.Guid(nullable: false),
                        OrderDetailPlanId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.OrderDetailPlanId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.OrderDetailPlanId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Guid(nullable: false),
                        OderIndex = c.Int(nullable: false),
                        Projectid = c.Guid(nullable: false),
                        PlanTitle = c.String(),
                        PlanFundedPeople = c.Int(nullable: false),
                        PlanShipDate = c.DateTime(nullable: false),
                        PlanDescription = c.String(),
                        PlanImgUrl = c.String(),
                        PlanePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Member_MemberId = c.Guid(),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Projects", t => t.Projectid, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.Projectid)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Guid(nullable: false),
                        ProjectName = c.String(),
                        FundingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Plans", "Projectid", "dbo.Projects");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.OrderDetails", "OrderDetailPlanId", "dbo.Plans");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderMemberId", "dbo.Members");
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropIndex("dbo.Plans", new[] { "Member_MemberId" });
            DropIndex("dbo.Plans", new[] { "Projectid" });
            DropIndex("dbo.OrderDetails", new[] { "OrderDetailPlanId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "OrderMemberId" });
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

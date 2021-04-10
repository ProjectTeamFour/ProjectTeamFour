namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveDB : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        AnnouncementId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        MemberId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(),
                        EditTime = c.DateTime(nullable: false),
                        EditUser = c.String(),
                    })
                .PrimaryKey(t => t.AnnouncementId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        AskedMemberId = c.Int(nullable: false),
                        Comment_Question = c.String(),
                        Comment_Time = c.DateTime(nullable: false),
                        Comment_Answer = c.String(),
                        ReadStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        ProjectPlanId = c.Int(nullable: false),
                        AddCarCarPlan = c.Boolean(nullable: false),
                        ProjectName = c.String(),
                        ProjectId = c.Int(nullable: false),
                        PlanTitle = c.String(),
                        PlanFundedPeople = c.Int(nullable: false),
                        PlanShipDate = c.DateTime(nullable: false),
                        PlanDescription = c.String(),
                        PlanImgUrl = c.String(),
                        PlanPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityLimit = c.Int(nullable: false),
                        SubmitLimit = c.Int(),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        OrderName = c.String(),
                        OrderAddress = c.String(),
                        OrderPhone = c.String(),
                        OrderConEmail = c.String(),
                        OrderTotalAccount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TradeNo = c.String(),
                        RtnCode = c.Int(nullable: false),
                        condition = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        Plan_PlanId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.Plan_PlanId)
                .Index(t => t.MemberId)
                .Index(t => t.Plan_PlanId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderDetailDes = c.String(),
                        OrderId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        PlanId = c.Int(nullable: false),
                        PlanTitle = c.String(),
                        OrderQuantity = c.Int(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlanImgUrl = c.String(),
                        condition = c.String(),
                        PlanShipDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.DraftProjects",
                c => new
                    {
                        DraftProjectId = c.Int(nullable: false, identity: true),
                        DraftProjectName = c.String(),
                        FundingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                        Fundedpeople = c.Int(nullable: false),
                        DraftProjectDescription = c.String(),
                        DraftProjectImgUrl = c.String(),
                        DraftProjectVideoUrl = c.String(),
                        DraftProject_Question = c.String(),
                        DraftProject_Answer = c.String(),
                        DraftCreatedDate = c.DateTime(nullable: false),
                        DraftSubmittedDate = c.DateTime(nullable: false),
                        DraftLastEditTime = c.DateTime(nullable: false),
                        DraftFundingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DraftFundedpeople = c.Int(nullable: false),
                        ApprovingStatus = c.Int(nullable: false),
                        ProjectStatus = c.String(),
                        DraftProjectPlansCount = c.Int(nullable: false),
                        DraftProjectCoverUrl = c.String(),
                        AmountThreshold = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatorName = c.String(),
                        DraftProjectMainUrl = c.String(),
                        DraftProjectPrincipal = c.String(),
                        IdentityNumber = c.String(),
                    })
                .PrimaryKey(t => t.DraftProjectId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.DraftPlans",
                c => new
                    {
                        DraftPlanId = c.Int(nullable: false, identity: true),
                        DraftProjectPlanId = c.Int(nullable: false),
                        DraftAddCarCarPlan = c.Boolean(nullable: false),
                        DraftProjectName = c.String(),
                        DraftProjectId = c.Int(nullable: false),
                        DraftPlanTitle = c.String(),
                        DraftPlanFundedPeople = c.Int(nullable: false),
                        DraftPlanShipDate = c.DateTime(nullable: false),
                        DraftPlanDescription = c.String(),
                        DraftPlanImgUrl = c.String(),
                        DraftPlanPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DraftQuantityLimit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DraftPlanId)
                .ForeignKey("dbo.DraftProjects", t => t.DraftProjectId, cascadeDelete: true)
                .Index(t => t.DraftProjectId);
            
            CreateTable(
                "dbo.FBLoginMembers",
                c => new
                    {
                        FBMemberId = c.Int(nullable: false),
                        AuthResponseAccessToken = c.String(),
                        AuthResponseUserId = c.String(),
                        AuthResponseExpiresIn = c.Int(nullable: false),
                        AuthResponseSocialPlatform = c.String(),
                        OriginalMemberId = c.Int(nullable: false),
                        GetMemberName = c.String(),
                        GetMemberBirth = c.DateTime(nullable: false),
                        GetMemberEmail = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FBMemberId)
                .ForeignKey("dbo.Members", t => t.FBMemberId)
                .Index(t => t.FBMemberId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        CountrollerName = c.String(),
                        ActionName = c.String(),
                        PermissionValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId);

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
                    MemberId = c.Int(nullable: false),
                    Fundedpeople = c.Int(nullable: false),
                    ProjectDescription = c.String(),
                    ProjectImgUrl = c.String(),
                    ProjectVideoUrl = c.String(),
                    Project_Question = c.String(),
                    Project_Answer = c.String(),
                    ProjectPlansCount = c.Int(nullable: false),
                    ProjectCoverUrl = c.String(),
                    AmountThreshold = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreatorName = c.String(),
                    ProjectMainUrl = c.String(),
                    ProjectPrincipal = c.String(),
                    IdentityNumber = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    SubmittedDate = c.DateTime(nullable: false),
                    LastEditTime = c.DateTime(nullable: false),
                    ApprovingStatus = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Members", t => t.MemberId)
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
                    Permission = c.Int(nullable: false),
                    Salt = c.String(),
                    Hash = c.String(),
                    ResetPasswordCode = c.String(),
                    IsThirdParty = c.String(),
                })
                .PrimaryKey(t => t.MemberId)
                .Index(t => t.MemberId);



        }
        
        public override void Down()
        {
        }
    }
}

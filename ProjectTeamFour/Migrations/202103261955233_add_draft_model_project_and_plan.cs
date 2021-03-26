namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_draft_model_project_and_plan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DraftProjects", "MemberId", "dbo.Members");
            DropIndex("dbo.DraftProjects", new[] { "MemberId" });
            RenameColumn(table: "dbo.DraftProjects", name: "MemberId", newName: "Member_MemberId");
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
            
            AddColumn("dbo.DraftProjects", "DraftAmountThreshold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DraftProjects", "DraftCategory", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftMemberConEmail", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftMemberPhone", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftProfileImgUrl", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftCreatorName", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftAboutMe", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftMemberWebsite", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftIdentityNumber", c => c.String());
            AddColumn("dbo.DraftProjects", "DraftCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftSubmittedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftLastEditTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftFundingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DraftProjects", "DraftFundedpeople", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "ApprovingStatus", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "ProjectStatus", c => c.String());
            AlterColumn("dbo.DraftProjects", "Member_MemberId", c => c.Int());
            CreateIndex("dbo.DraftProjects", "Member_MemberId");
            AddForeignKey("dbo.DraftProjects", "Member_MemberId", "dbo.Members", "MemberId");
            DropColumn("dbo.DraftProjects", "FundingAmount");
            DropColumn("dbo.DraftProjects", "Category");
            DropColumn("dbo.DraftProjects", "StartDate");
            DropColumn("dbo.DraftProjects", "EndDate");
            DropColumn("dbo.DraftProjects", "Fundedpeople");
            DropColumn("dbo.DraftProjects", "DraftProjectDescription");
            DropColumn("dbo.DraftProjects", "DraftProjectPlansCount");
            DropColumn("dbo.DraftProjects", "AmountThreshold");
            DropColumn("dbo.DraftProjects", "CreatorName");
            DropColumn("dbo.DraftProjects", "IdentityNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DraftProjects", "IdentityNumber", c => c.String());
            AddColumn("dbo.DraftProjects", "CreatorName", c => c.String());
            AddColumn("dbo.DraftProjects", "AmountThreshold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DraftProjects", "DraftProjectPlansCount", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftProjectDescription", c => c.String());
            AddColumn("dbo.DraftProjects", "Fundedpeople", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "Category", c => c.String());
            AddColumn("dbo.DraftProjects", "FundingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.DraftProjects", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.DraftPlans", "DraftProjectId", "dbo.DraftProjects");
            DropIndex("dbo.DraftPlans", new[] { "DraftProjectId" });
            DropIndex("dbo.DraftProjects", new[] { "Member_MemberId" });
            AlterColumn("dbo.DraftProjects", "Member_MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.DraftProjects", "ProjectStatus");
            DropColumn("dbo.DraftProjects", "ApprovingStatus");
            DropColumn("dbo.DraftProjects", "DraftFundedpeople");
            DropColumn("dbo.DraftProjects", "DraftFundingAmount");
            DropColumn("dbo.DraftProjects", "DraftLastEditTime");
            DropColumn("dbo.DraftProjects", "DraftSubmittedDate");
            DropColumn("dbo.DraftProjects", "DraftCreatedDate");
            DropColumn("dbo.DraftProjects", "DraftIdentityNumber");
            DropColumn("dbo.DraftProjects", "DraftMemberWebsite");
            DropColumn("dbo.DraftProjects", "DraftAboutMe");
            DropColumn("dbo.DraftProjects", "DraftCreatorName");
            DropColumn("dbo.DraftProjects", "DraftProfileImgUrl");
            DropColumn("dbo.DraftProjects", "DraftMemberPhone");
            DropColumn("dbo.DraftProjects", "DraftMemberConEmail");
            DropColumn("dbo.DraftProjects", "DraftEndDate");
            DropColumn("dbo.DraftProjects", "DraftStartDate");
            DropColumn("dbo.DraftProjects", "DraftCategory");
            DropColumn("dbo.DraftProjects", "DraftAmountThreshold");
            DropTable("dbo.DraftPlans");
            RenameColumn(table: "dbo.DraftProjects", name: "Member_MemberId", newName: "MemberId");
            CreateIndex("dbo.DraftProjects", "MemberId");
            AddForeignKey("dbo.DraftProjects", "MemberId", "dbo.Members", "MemberId", cascadeDelete: true);
        }
    }
}

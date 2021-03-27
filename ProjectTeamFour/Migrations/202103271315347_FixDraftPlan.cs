namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDraftPlan : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DraftPlans", "DraftProjectId", "dbo.DraftProjects");
            DropIndex("dbo.DraftPlans", new[] { "DraftProjectId" });
            DropTable("dbo.DraftPlans");
        }
    }
}

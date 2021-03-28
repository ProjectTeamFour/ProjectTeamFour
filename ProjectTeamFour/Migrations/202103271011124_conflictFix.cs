namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflictFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DraftProjects", "DraftCreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftSubmittedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftLastEditTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DraftProjects", "DraftFundingAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DraftProjects", "DraftFundedpeople", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "ApprovingStatus", c => c.Int(nullable: false));
            AddColumn("dbo.DraftProjects", "ProjectStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DraftProjects", "ProjectStatus");
            DropColumn("dbo.DraftProjects", "ApprovingStatus");
            DropColumn("dbo.DraftProjects", "DraftFundedpeople");
            DropColumn("dbo.DraftProjects", "DraftFundingAmount");
            DropColumn("dbo.DraftProjects", "DraftLastEditTime");
            DropColumn("dbo.DraftProjects", "DraftSubmittedDate");
            DropColumn("dbo.DraftProjects", "DraftCreatedDate");
        }
    }
}

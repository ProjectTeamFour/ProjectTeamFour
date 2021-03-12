namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_Projects_and_Commets_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ReadStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "SubmittedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "LastEditTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ApprovingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ApprovingStatus");
            DropColumn("dbo.Projects", "LastEditTime");
            DropColumn("dbo.Projects", "SubmittedDate");
            DropColumn("dbo.Projects", "CreatedDate");
            DropColumn("dbo.Comments", "ReadStatus");
        }
    }
}

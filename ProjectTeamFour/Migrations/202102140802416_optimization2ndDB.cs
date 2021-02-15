namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimization2ndDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "AmountThreshold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Projects", "CreatorName", c => c.String());
            AddColumn("dbo.Projects", "ProjectMainUrl", c => c.String());
            AlterColumn("dbo.Projects", "MemberId", c => c.Guid(nullable: false));
            DropColumn("dbo.Projects", "Project_Question");
            DropColumn("dbo.Projects", "Project_Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Project_Answer", c => c.String());
            AddColumn("dbo.Projects", "Project_Question", c => c.String());
            AlterColumn("dbo.Projects", "MemberId", c => c.String());
            DropColumn("dbo.Projects", "ProjectMainUrl");
            DropColumn("dbo.Projects", "CreatorName");
            DropColumn("dbo.Projects", "AmountThreshold");
        }
    }
}

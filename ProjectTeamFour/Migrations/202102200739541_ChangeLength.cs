namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Projects", "ProjectVideoUrl", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "ProjectCoverUrl", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "CreatorName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Projects", "ProjectMainUrl", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectMainUrl", c => c.String());
            AlterColumn("dbo.Projects", "CreatorName", c => c.String());
            AlterColumn("dbo.Projects", "ProjectCoverUrl", c => c.String());
            AlterColumn("dbo.Projects", "ProjectVideoUrl", c => c.String());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
        }
    }
}

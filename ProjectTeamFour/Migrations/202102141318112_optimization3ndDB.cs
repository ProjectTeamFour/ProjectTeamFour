namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimization3ndDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectImgUrl", c => c.String());
            AddColumn("dbo.Projects", "Project_Question", c => c.String());
            AddColumn("dbo.Projects", "Project_Answer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Project_Answer");
            DropColumn("dbo.Projects", "Project_Question");
            DropColumn("dbo.Projects", "ProjectImgUrl");
        }
    }
}

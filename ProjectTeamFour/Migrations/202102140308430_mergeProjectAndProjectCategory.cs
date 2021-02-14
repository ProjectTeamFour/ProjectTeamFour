namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergeProjectAndProjectCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "ProjectImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectImgUrl", c => c.String());
        }
    }
}

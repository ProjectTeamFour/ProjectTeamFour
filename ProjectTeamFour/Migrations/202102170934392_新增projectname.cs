namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 新增projectname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "ProjectName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "ProjectName");
        }
    }
}

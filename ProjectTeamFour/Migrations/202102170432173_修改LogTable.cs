namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改LogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Content", c => c.String());
            DropColumn("dbo.Logs", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "Path", c => c.String());
            DropColumn("dbo.Logs", "Content");
        }
    }
}

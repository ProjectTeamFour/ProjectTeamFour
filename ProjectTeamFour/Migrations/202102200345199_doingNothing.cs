namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doingNothing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "dateLine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "dateLine", c => c.Double(nullable: false));
        }
    }
}

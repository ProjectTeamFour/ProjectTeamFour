namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectIdForOD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProjectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "ProjectId");
        }
    }
}

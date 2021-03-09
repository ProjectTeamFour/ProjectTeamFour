namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addplandatamodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "AddCarCarPlan", c => c.Boolean(nullable: false));
            DropColumn("dbo.Projects", "AddCarCarPlan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "AddCarCarPlan", c => c.Boolean(nullable: false));
            DropColumn("dbo.Plans", "AddCarCarPlan");
        }
    }
}

namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "condition", c => c.String());
            AddColumn("dbo.Projects", "ProjectPrincipal", c => c.String());
            AddColumn("dbo.Projects", "IdentityNumber", c => c.String());
            AddColumn("dbo.Projects", "AddCarCarPlan", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "AddCarCarPlan");
            DropColumn("dbo.Projects", "IdentityNumber");
            DropColumn("dbo.Projects", "ProjectPrincipal");
            DropColumn("dbo.Orders", "condition");
        }
    }
}

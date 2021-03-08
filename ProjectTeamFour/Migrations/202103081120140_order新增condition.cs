namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order新增condition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "condition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "condition");
        }
    }
}

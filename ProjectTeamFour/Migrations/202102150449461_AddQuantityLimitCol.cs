namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityLimitCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "QuantityLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "QuantityLimit");
        }
    }
}

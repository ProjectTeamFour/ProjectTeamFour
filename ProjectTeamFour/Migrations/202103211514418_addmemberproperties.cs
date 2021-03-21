namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmemberproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Salt", c => c.String());
            AddColumn("dbo.Members", "Hash", c => c.String());
            AddColumn("dbo.Members", "ResetPasswordCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "ResetPasswordCode");
            DropColumn("dbo.Members", "Hash");
            DropColumn("dbo.Members", "Salt");
        }
    }
}

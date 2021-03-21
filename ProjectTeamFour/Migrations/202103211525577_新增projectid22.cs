namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 新增projectid22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "Salt");
            DropColumn("dbo.Members", "Hash");
            DropColumn("dbo.Members", "ResetPasswordCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "ResetPasswordCode", c => c.String());
            AddColumn("dbo.Members", "Hash", c => c.String());
            AddColumn("dbo.Members", "Salt", c => c.String());
        }
    }
}

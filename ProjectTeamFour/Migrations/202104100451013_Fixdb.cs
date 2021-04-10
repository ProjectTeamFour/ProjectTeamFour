namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixdb : DbMigration
    {
        public override void Up()
        {

        }

        public override void Down()
        {
            AlterColumn("dbo.Members", "Salt", c => c.String());
            AlterColumn("dbo.Members", "Hash", c => c.String());
            AlterColumn("dbo.Members", "ResetPasswordCode", c => c.String());
            AlterColumn("dbo.Members", "IsThirdParty", c => c.String());
        }
    }
}

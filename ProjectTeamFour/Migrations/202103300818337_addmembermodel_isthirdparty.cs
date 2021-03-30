namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmembermodel_isthirdparty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "IsThirdParty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "IsThirdParty");
        }
    }
}

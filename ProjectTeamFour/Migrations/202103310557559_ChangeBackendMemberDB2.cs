namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBackendMemberDB2 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Backendmembers", "AboutMe");
            DropColumn("dbo.Backendmembers", "ProfileImgUrl");
            DropColumn("dbo.Backendmembers", "MemberWebsite");
        }
    }
}

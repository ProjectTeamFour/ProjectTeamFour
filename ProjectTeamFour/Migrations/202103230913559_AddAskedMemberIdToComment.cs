namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAskedMemberIdToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AskedMemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "AskedMemberId");
        }
    }
}

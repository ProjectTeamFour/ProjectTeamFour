namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 將member改為int1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "MemberId", c => c.Int());
        }
    }
}

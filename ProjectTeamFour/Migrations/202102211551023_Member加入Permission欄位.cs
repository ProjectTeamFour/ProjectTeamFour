namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Member加入Permission欄位 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Permission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Permission");
        }
    }
}

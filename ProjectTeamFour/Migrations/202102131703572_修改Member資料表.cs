namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改Member資料表 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plans", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.Plans", new[] { "Member_MemberId" });
            DropColumn("dbo.Plans", "Member_MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plans", "Member_MemberId", c => c.Guid());
            CreateIndex("dbo.Plans", "Member_MemberId");
            AddForeignKey("dbo.Plans", "Member_MemberId", "dbo.Members", "MemberId");
        }
    }
}

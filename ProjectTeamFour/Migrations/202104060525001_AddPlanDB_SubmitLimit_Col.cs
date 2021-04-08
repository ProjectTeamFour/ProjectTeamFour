namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanDB_SubmitLimit_Col : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        AnnouncementId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        MemberId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(),
                        EditTime = c.DateTime(nullable: false),
                        EditUser = c.String(),
                    })
                .PrimaryKey(t => t.AnnouncementId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            AddColumn("dbo.OrderDetails", "PlanShipDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Plans", "SubmitLimit", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "MemberId", "dbo.Members");
            DropIndex("dbo.Announcements", new[] { "MemberId" });
            DropColumn("dbo.Plans", "SubmitLimit");
            DropColumn("dbo.OrderDetails", "PlanShipDate");
            DropTable("dbo.Announcements");
        }
    }
}

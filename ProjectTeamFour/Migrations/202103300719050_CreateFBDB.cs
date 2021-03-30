namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFBDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FBLoginMembers",
                c => new
                    {
                        FBMemberId = c.Int(nullable: false),
                        AuthResponseAccessToken = c.String(),
                        AuthResponseUserId = c.String(),
                        AuthResponseExpiresIn = c.Int(nullable: false),
                        AuthResponseSocialPlatform = c.String(),
                        OriginalMemberId = c.Int(nullable: false),
                        GetMemberName = c.String(),
                        GetMemberBirth = c.DateTime(nullable: false),
                        GetMemberEmail = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FBMemberId)
                .ForeignKey("dbo.Members", t => t.FBMemberId)
                .Index(t => t.FBMemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FBLoginMembers", "FBMemberId", "dbo.Members");
            DropIndex("dbo.FBLoginMembers", new[] { "FBMemberId" });
            DropTable("dbo.FBLoginMembers");
        }
    }
}

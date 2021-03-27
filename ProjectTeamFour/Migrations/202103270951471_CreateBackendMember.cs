namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBackendMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Backendmembers",
                c => new
                {
                    MemberId = c.Int(nullable: false),
                    MemberName = c.String(),

                    MemberAccount = c.String(),
                    MemberPassword = c.String(),
                    MemberAddress = c.String(),
                    MemberPhone = c.String(),
                    MemberRegEmail = c.String(),
                    MemberConEmail = c.String(),
                    Gender = c.String(),
                    MemberBirth = c.DateTime(nullable: false),
                    AboutMe = c.String(),
                    ProfileImgUrl = c.String(),
                    MemberWebsite = c.String(),
                    BackendIdentity=c.Boolean(nullable: false),
                    MemberMessage = c.String(),
                    Permission=c.Int(),
                    Salt=c.String(),
                    Hash=c.String(),
                    ResetPasswordCode=c.String()
                }).PrimaryKey(t => t.MemberId);
        }
        
        public override void Down()
        {
        }
    }
}

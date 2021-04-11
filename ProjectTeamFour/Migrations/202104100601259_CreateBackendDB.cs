namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBackendDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Backendmembers",
            c => new
            {
                MemberId = c.Int(nullable: false, identity: true),
                MemberName = c.String(),
                MemberAccount = c.String(),
                MemberPassword = c.String(),
                MemberAddress = c.String(),
                MemberPhone = c.String(),
                MemberRegEmail = c.String(),
                MemberConEmail = c.String(),
                Gender = c.String(),
                MemberBirth = c.DateTime(nullable: false),
                LoginTime = c.DateTime(nullable: false),
                BackendIdentity = c.Boolean(nullable: false),
                MemberMessage = c.String(),
                Permission = c.Int(nullable: false),
                Salt = c.String(),
                Hash = c.String(),
                ResetPasswordCode = c.String(),
            })
            .PrimaryKey(t => t.MemberId)
            .Index(t => t.MemberId);
                }
        
        public override void Down()
        {
        }
    }
}

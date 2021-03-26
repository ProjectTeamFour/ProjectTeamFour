namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDraftDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DraftProjects",
                c => new
                    {
                        DraftProjectId = c.Int(nullable: false, identity: true),
                        DraftProjectName = c.String(),
                        FundingAmount = c.Decimal(nullable: true, precision: 18, scale: 2),
                        Category = c.String(),
                        StartDate = c.DateTime(nullable: true),
                        EndDate = c.DateTime(nullable: true),
                        MemberId = c.Int(nullable: true),
                        Fundedpeople = c.Int(nullable: true),
                        DraftProjectDescription = c.String(),
                        DraftProjectImgUrl = c.String(),
                        DraftProjectVideoUrl = c.String(),
                        DraftProject_Question = c.String(),
                        DraftProject_Answer = c.String(),
                        DraftProjectPlansCount = c.Int(nullable: true),
                        DraftProjectCoverUrl = c.String(),
                        AmountThreshold = c.Decimal(nullable: true, precision: 18, scale: 2),
                        CreatorName = c.String(),
                        DraftProjectMainUrl = c.String(),
                        DraftProjectPrincipal = c.String(),
                        IdentityNumber = c.String(),
                    })
                .PrimaryKey(t => t.DraftProjectId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DraftProjects", "MemberId", "dbo.Members");
            DropIndex("dbo.DraftProjects", new[] { "MemberId" });
            DropTable("dbo.DraftProjects");
        }
    }
}

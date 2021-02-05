namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
        }
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Images", new[] { "ProjectId" });
            DropTable("dbo.Images");
        }
    }
}

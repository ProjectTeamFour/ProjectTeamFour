namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Images", new[] { "ProjectId" });
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateIndex("dbo.Images", "ProjectId");
            AddForeignKey("dbo.Images", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}

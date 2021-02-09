namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Images", new[] { "ProjectId" });
            DropTable("dbo.Images");
            DropTable("dbo.Projects");
            DropTable("dbo.Members");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Brief = c.String(),
                        Category = c.String(),
                        Status = c.String(),
                        GoalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FundedAnount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Progress = c.Int(nullable: false),
                        DeadLine = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Category = c.String(),
                        GoalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FundedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FundedPeople = c.Int(nullable: false),
                        ifSucceed = c.Boolean(nullable: false),
                        CountDownDays = c.Int(nullable: false),
                        DeadLine = c.DateTime(nullable: false),
                        CreatorName = c.String(),
                        CreatorLinkUrl = c.String(),
                        ProjectContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account = c.String(),
                        PassWord = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Pulisher = c.String(),
                        Title = c.String(),
                        CategoryName = c.String(),
                        MainImage = c.String(),
                        D_DateTime = c.DateTime(nullable: false),
                        GoalMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NowMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProjectId);
            
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

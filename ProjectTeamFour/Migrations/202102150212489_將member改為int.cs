namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 將member改為int : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectImgUrl", c => c.String());
            AddColumn("dbo.Projects", "AmountThreshold", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Projects", "CreatorName", c => c.String());
            AddColumn("dbo.Projects", "ProjectMainUrl", c => c.String());
            AlterColumn("dbo.Projects", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "MemberId", c => c.String());
            DropColumn("dbo.Projects", "ProjectMainUrl");
            DropColumn("dbo.Projects", "CreatorName");
            DropColumn("dbo.Projects", "AmountThreshold");
            DropColumn("dbo.Projects", "ProjectImgUrl");
        }
    }
}

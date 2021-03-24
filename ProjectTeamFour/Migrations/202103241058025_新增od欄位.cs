namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 新增od欄位 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "condition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "condition");
        }
    }
}

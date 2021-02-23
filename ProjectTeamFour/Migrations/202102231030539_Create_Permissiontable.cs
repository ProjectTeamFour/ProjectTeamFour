namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Permissiontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        CountrollerName = c.String(),
                        ActionName = c.String(),
                        PermissionValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Permissions");
        }
    }
}

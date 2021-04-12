namespace GameJunkies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAppRolev2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserRole", "AppRoleId", "dbo.AppRole");
            DropForeignKey("dbo.ApplicationUserRole", "GamerId", "dbo.Gamer");
            DropIndex("dbo.ApplicationUserRole", new[] { "GamerId" });
            DropIndex("dbo.ApplicationUserRole", new[] { "AppRoleId" });
            RenameColumn(table: "dbo.ApplicationUserRole", name: "AppRoleId", newName: "AppRole_Id");
            RenameColumn(table: "dbo.ApplicationUserRole", name: "GamerId", newName: "Gamer_Id");
            AlterColumn("dbo.ApplicationUserRole", "Gamer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ApplicationUserRole", "AppRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationUserRole", "AppRole_Id");
            CreateIndex("dbo.ApplicationUserRole", "Gamer_Id");
            AddForeignKey("dbo.ApplicationUserRole", "AppRole_Id", "dbo.AppRole", "Id");
            AddForeignKey("dbo.ApplicationUserRole", "Gamer_Id", "dbo.Gamer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRole", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.ApplicationUserRole", "AppRole_Id", "dbo.AppRole");
            DropIndex("dbo.ApplicationUserRole", new[] { "Gamer_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "AppRole_Id" });
            AlterColumn("dbo.ApplicationUserRole", "AppRole_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ApplicationUserRole", "Gamer_Id", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.ApplicationUserRole", name: "Gamer_Id", newName: "GamerId");
            RenameColumn(table: "dbo.ApplicationUserRole", name: "AppRole_Id", newName: "AppRoleId");
            CreateIndex("dbo.ApplicationUserRole", "AppRoleId");
            CreateIndex("dbo.ApplicationUserRole", "GamerId");
            AddForeignKey("dbo.ApplicationUserRole", "GamerId", "dbo.Gamer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserRole", "AppRoleId", "dbo.AppRole", "Id", cascadeDelete: true);
        }
    }
}

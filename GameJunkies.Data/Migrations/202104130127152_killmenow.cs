namespace GameJunkies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserRole", "GamerId", "dbo.Gamer");
            DropForeignKey("dbo.ApplicationUserRole", "AppRoleId", "dbo.AppRole");
            DropTable("dbo.ApplicationUserRole");
            DropTable("dbo.AppRole");
            CreateTable(
                "dbo.AppRole",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ApplicationUserRole",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                    GamerId = c.String(nullable: false, maxLength: 128),
                    AppRoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRole", t => t.AppRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Gamer", t => t.GamerId, cascadeDelete: true)
                .Index(t => t.GamerId)
                .Index(t => t.AppRoleId);




        }

        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRole", "GamerId", "dbo.Gamer");
            DropForeignKey("dbo.AppUserLogin", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.AppUserClaim", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.ApplicationUserRole", "AppRoleId", "dbo.AppRole");
            DropForeignKey("dbo.ConsoleGame", "GameId", "dbo.Game");
            DropForeignKey("dbo.ConsoleGame", "ConsoleId", "dbo.Console");
            DropForeignKey("dbo.OwnedConsole", "GameInfoId", "dbo.GamerInfo");
            DropForeignKey("dbo.OwnedGame", "GamerInfoId", "dbo.GamerInfo");
            DropForeignKey("dbo.OwnedGame", "GameId", "dbo.Game");
            DropForeignKey("dbo.RetailerGame", "RetailerId", "dbo.Retailer");
            DropForeignKey("dbo.RetailerConsole", "RetailerId", "dbo.Retailer");
            DropForeignKey("dbo.RetailerConsole", "ConsoleId", "dbo.Console");
            DropForeignKey("dbo.RetailerGame", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Game", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Game", "DeveloperId", "dbo.Developer");
            DropForeignKey("dbo.OwnedConsole", "ConsoleId", "dbo.Console");
            DropIndex("dbo.AppUserLogin", new[] { "Gamer_Id" });
            DropIndex("dbo.AppUserClaim", new[] { "Gamer_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "AppRoleId" });
            DropIndex("dbo.ApplicationUserRole", new[] { "GamerId" });
            DropIndex("dbo.RetailerConsole", new[] { "RetailerId" });
            DropIndex("dbo.RetailerConsole", new[] { "ConsoleId" });
            DropIndex("dbo.RetailerGame", new[] { "RetailerId" });
            DropIndex("dbo.RetailerGame", new[] { "GameId" });
            DropIndex("dbo.Game", new[] { "PublisherId" });
            DropIndex("dbo.Game", new[] { "DeveloperId" });
            DropIndex("dbo.Game", new[] { "GenreId" });
            DropIndex("dbo.OwnedGame", new[] { "GamerInfoId" });
            DropIndex("dbo.OwnedGame", new[] { "GameId" });
            DropIndex("dbo.OwnedConsole", new[] { "GameInfoId" });
            DropIndex("dbo.OwnedConsole", new[] { "ConsoleId" });
            DropIndex("dbo.ConsoleGame", new[] { "GameId" });
            DropIndex("dbo.ConsoleGame", new[] { "ConsoleId" });
            DropTable("dbo.AppUserLogin");
            DropTable("dbo.AppUserClaim");
            DropTable("dbo.Gamer");
            DropTable("dbo.ApplicationUserRole");
            DropTable("dbo.AppRole");
            DropTable("dbo.RetailerConsole");
            DropTable("dbo.Retailer");
            DropTable("dbo.RetailerGame");
            DropTable("dbo.Publisher");
            DropTable("dbo.Genre");
            DropTable("dbo.Developer");
            DropTable("dbo.Game");
            DropTable("dbo.OwnedGame");
            DropTable("dbo.GamerInfo");
            DropTable("dbo.OwnedConsole");
            DropTable("dbo.Console");
            DropTable("dbo.ConsoleGame");
        }
    }
}
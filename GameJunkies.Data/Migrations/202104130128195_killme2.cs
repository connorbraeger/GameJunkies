namespace GameJunkies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class killme2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        AppRole_Id = c.String(maxLength: 128),
                        Gamer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRole", t => t.AppRole_Id)
                .ForeignKey("dbo.Gamer", t => t.Gamer_Id)
                .Index(t => t.AppRole_Id)
                .Index(t => t.Gamer_Id);
            
            CreateTable(
                "dbo.AppRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gamer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Gamer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamer", t => t.Gamer_Id)
                .Index(t => t.Gamer_Id);
            
            CreateTable(
                "dbo.AppUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Gamer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Gamer", t => t.Gamer_Id)
                .Index(t => t.Gamer_Id);
            
            CreateTable(
                "dbo.ConsoleGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsoleId = c.Int(),
                        GameId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Console", t => t.ConsoleId)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.ConsoleId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Console",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Single(nullable: false),
                        ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OwnedConsole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsoleId = c.Int(),
                        GameInfoId = c.Int(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Console", t => t.ConsoleId)
                .ForeignKey("dbo.GamerInfo", t => t.GameInfoId)
                .Index(t => t.ConsoleId)
                .Index(t => t.GameInfoId);
            
            CreateTable(
                "dbo.GamerInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GamerTag = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OwnedGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(),
                        GamerInfoId = c.Int(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.GamerInfo", t => t.GamerInfoId)
                .Index(t => t.GameId)
                .Index(t => t.GamerInfoId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ParentalRating = c.String(nullable: false),
                        GenreId = c.Int(),
                        DeveloperId = c.Int(),
                        PublisherId = c.Int(),
                        Rating = c.Single(nullable: false),
                        ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developer", t => t.DeveloperId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .ForeignKey("dbo.Publisher", t => t.PublisherId)
                .Index(t => t.GenreId)
                .Index(t => t.DeveloperId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Developer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CompanySize = c.String(),
                        Country = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CompanySize = c.String(),
                        Country = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RetailerGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(),
                        RetailerId = c.Int(),
                        IsInStock = c.Boolean(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        RetailerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Retailer", t => t.RetailerId)
                .Index(t => t.GameId)
                .Index(t => t.RetailerId);
            
            CreateTable(
                "dbo.Retailer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WebsiteUrl = c.String(nullable: false),
                        HasPhysicalLocations = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RetailerConsole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsoleId = c.Int(),
                        RetailerId = c.Int(),
                        IsInStock = c.Boolean(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        RetailerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Console", t => t.ConsoleId)
                .ForeignKey("dbo.Retailer", t => t.RetailerId)
                .Index(t => t.ConsoleId)
                .Index(t => t.RetailerId);
            
        }
        
        public override void Down()
        {
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
            DropForeignKey("dbo.ApplicationUserRole", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.AppUserLogin", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.AppUserClaim", "Gamer_Id", "dbo.Gamer");
            DropForeignKey("dbo.ApplicationUserRole", "AppRole_Id", "dbo.AppRole");
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
            DropIndex("dbo.AppUserLogin", new[] { "Gamer_Id" });
            DropIndex("dbo.AppUserClaim", new[] { "Gamer_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "Gamer_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "AppRole_Id" });
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
            DropTable("dbo.AppUserLogin");
            DropTable("dbo.AppUserClaim");
            DropTable("dbo.Gamer");
            DropTable("dbo.AppRole");
            DropTable("dbo.ApplicationUserRole");
        }
    }
}

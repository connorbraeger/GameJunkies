namespace GameJunkies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedModifiedRequirement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Console", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.GamerInfo", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Game", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Developer", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Genre", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Publisher", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Retailer", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Retailer", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Publisher", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Genre", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Developer", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Game", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.GamerInfo", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Console", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}

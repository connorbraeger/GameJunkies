namespace GameJunkies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameJunkies.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameJunkies.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            using (var ctx = new ApplicationDbContext()) 
            {
                if(ctx.Genres.Count() == 0)
                {
                    var Genre = new Genre()
                    {
                        Name = "Not specified",
                        Description = "",
                        CreatedUtc = DateTimeOffset.Now,
                        ModifiedUtc = null
                    };
                    ctx.Genres.Add(Genre);
                }
                if (ctx.Developers.Count() == 0)
                {
                    var dev = new Developer()
                    {
                        Name = "Default",
                        CompanySize = "",
                        Country = "",
                        CreatedUtc = DateTimeOffset.Now,
                        ModifiedUtc = null
                    };
                    ctx.Developers.Add(dev);
                }
                if (ctx.Publishers.Count() == 0)
                {
                    var pub = new Publisher()
                    {
                        Name = "Default",
                        CompanySize = "",
                        Country = "",
                        CreatedUtc = DateTimeOffset.Now,
                        ModifiedUtc = null
                    };
                    ctx.Publishers.Add(pub);
                }
            }
        }
    }
}

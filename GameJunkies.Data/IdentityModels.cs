using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameJunkies.Data
{
    // You can add profile data for the user by adding more properties to your Gamer class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Gamer : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Gamer> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;

        }
        
        [ForeignKey(nameof(GamerInfo))]
        public int? GamerInfoId { get; set; }
        
        public int MyProperty { get; set; }
        public virtual GamerInfo GamerInfo { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<Gamer>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<GamerInfo> GamerInfos { get; set; }
        public DbSet<Console> Consoles{ get; set; }
        public DbSet<ConsoleGame> ConsoleGames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OwnedConsole> OwnedConsoles { get; set; }
        public DbSet<OwnedGame> OwnedGames { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<RetailerConsole> RetailerConsoles { get; set; }
        public DbSet<RetailerGame> RetailerGames { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(IdentityUserLogin => IdentityUserLogin.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}
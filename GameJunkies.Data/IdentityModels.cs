using System;
using System.ComponentModel.DataAnnotations;
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
    public class Gamer : IdentityUser<string, AppUserLogin, ApplicationUserRole, AppUserClaim>
    {
    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Gamer,string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;

        }
        
      //  [ForeignKey(nameof(GamerInfo))]
     //   public int? GamerInfoId { get; set; }
        
     //   public virtual GamerInfo GamerInfo { get; set; }

    }
    public class AppUserClaim : IdentityUserClaim<string> { }
    public class AppUserLogin : IdentityUserLogin<string> { }
    public class AppRole : IdentityRole<string, ApplicationUserRole>
    {
        public AppRole():base()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public class ApplicationUserRole : IdentityUserRole<string>

    {

        
        public virtual Gamer Gamer { get; set; }
     
        public virtual AppRole AppRole { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<Gamer, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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
        //public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
       // public DbSet<Gamer> Gamers{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<AppUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul=>iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => new { iur.UserId, iur.RoleId });

        }
    }
}
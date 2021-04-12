using GameJunkies.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(GameJunkies.WebMVC.Startup))]
namespace GameJunkies.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var roleManager = new ApplicationRoleManager(new RoleStore<AppRole, string, ApplicationUserRole>(ctx));
                var userManager = new ApplicationUserManager( new UserStore<Gamer, AppRole, string, AppUserLogin, ApplicationUserRole, AppUserClaim>(ctx));
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new AppRole();
                    role.Name = "Admin";
                    
                    roleManager.Create(role);

                    var user = new Gamer();
                    user.Email = "cjbraeger@gmail.com";
                    user.UserName = "cjbraeger@gmail.com";
                    user.Id = Guid.NewGuid().ToString();
                    string password = "Password123!";
                    var chkUser = userManager.Create(user, password);
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(user.Id, "Admin");
                       
                    }
                }
            }
        }
        
    }
}

using Autofac;
using Autofac.Integration.Mvc;
using GameJunkies.Data;
using GameJunkies.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(GameJunkies.WebMVC.Startup))]
namespace GameJunkies.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<GameService>().As<Contracts.IGameService>();
            builder.RegisterType<ConsoleService>().As<Contracts.IConsoleService>();
            builder.RegisterType<ConsoleGameService>().As<Contracts.IConsoleGameService>();
            builder.RegisterType<DeveloperService>().As<Contracts.IDeveloperService>();
            builder.RegisterType<GenreService>().As<Contracts.IGenreService>();
            builder.RegisterType<PublisherService>().As<Contracts.IPublisherService>();
            builder.RegisterType<SearchService>().As<Contracts.ISearchService>();
            builder.RegisterType<RetailerService>().As<Contracts.IRetailerService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
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

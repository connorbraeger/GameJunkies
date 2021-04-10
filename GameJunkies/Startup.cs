using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameJunkies.WebMVC.Startup))]
namespace GameJunkies.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

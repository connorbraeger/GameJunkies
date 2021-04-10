using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameJunkies.Startup))]
namespace GameJunkies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

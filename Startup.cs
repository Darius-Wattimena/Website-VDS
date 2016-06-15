using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NederlandsWebsiteVDS.Startup))]
namespace NederlandsWebsiteVDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

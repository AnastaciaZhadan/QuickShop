using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickShop.Startup))]
namespace QuickShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

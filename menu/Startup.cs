using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(menu.Startup))]
namespace menu
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

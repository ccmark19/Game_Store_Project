using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gaimz.Startup))]
namespace gaimz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

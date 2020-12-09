using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VOD.Startup))]
namespace VOD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HippoCampus.Startup))]
namespace HippoCampus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

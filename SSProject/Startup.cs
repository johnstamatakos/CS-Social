using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSProject.Startup))]
namespace SSProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

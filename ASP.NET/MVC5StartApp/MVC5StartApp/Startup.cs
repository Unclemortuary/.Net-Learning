using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5StartApp.Startup))]
namespace MVC5StartApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

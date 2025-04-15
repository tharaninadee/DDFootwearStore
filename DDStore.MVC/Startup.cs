using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDStore.MVC.Startup))]
namespace DDStore.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

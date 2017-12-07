using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(agenda.Startup))]
namespace agenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

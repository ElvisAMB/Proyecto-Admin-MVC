using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(practica1.Startup))]
namespace practica1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

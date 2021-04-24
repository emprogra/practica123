using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCasa.Startup))]
namespace WebCasa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IDENT01.Startup))]
namespace IDENT01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

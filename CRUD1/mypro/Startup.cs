using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mypro.Startup))]
namespace mypro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

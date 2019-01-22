using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoDB_2.Startup))]
namespace MongoDB_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

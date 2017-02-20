using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Name.Startup))]
namespace Name
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwest_Labs.Startup))]
namespace Northwest_Labs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

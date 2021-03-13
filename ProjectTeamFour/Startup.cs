using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTeamFour.Startup))]

namespace ProjectTeamFour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
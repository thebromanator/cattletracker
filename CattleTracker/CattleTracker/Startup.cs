using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CattleTracker.App_Start.Startup))]
namespace CattleTracker.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

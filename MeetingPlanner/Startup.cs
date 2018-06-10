using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingPlanner.Startup))]
namespace MeetingPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMSBLL.Startup))]
namespace SMSBLL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

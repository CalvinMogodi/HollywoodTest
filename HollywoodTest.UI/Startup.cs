using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HollywoodTest.UI.Startup))]
namespace HollywoodTest.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

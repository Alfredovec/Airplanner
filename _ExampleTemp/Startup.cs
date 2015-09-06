using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_ExampleTemp.Startup))]
namespace _ExampleTemp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

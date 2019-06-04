using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeShop.Startup))]
namespace CoffeeShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

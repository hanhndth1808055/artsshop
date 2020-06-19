using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalArtsShop.Startup))]
namespace FinalArtsShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

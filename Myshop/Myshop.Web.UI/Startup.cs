using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myshop.Web.UI.Startup))]
namespace Myshop.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

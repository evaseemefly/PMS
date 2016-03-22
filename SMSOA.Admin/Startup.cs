using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMSOA.Admin.Startup))]
namespace SMSOA.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

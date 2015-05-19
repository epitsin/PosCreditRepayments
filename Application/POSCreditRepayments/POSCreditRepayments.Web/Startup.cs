using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POSCreditRepayments.Web.Startup))]
namespace POSCreditRepayments.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

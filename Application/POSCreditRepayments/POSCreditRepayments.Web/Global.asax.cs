using POSCreditRepayments.Data;
using POSCreditRepayments.Data.Migrations;
using POSCreditRepayments.Web.App_Start;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POSCreditRepayments.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Selects Razor as the only view engine
            ViewEnginesConfig.RegisterViewEngines(ViewEngines.Engines);

            // Mapping configuration
            AutoMapperConfig.RegisterMappings();

            // Migration tactics for the database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<POSCreditRepaymentsDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

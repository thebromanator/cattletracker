using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CattleTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            CattleTracker.App_Start.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            CattleTracker.App_Start.RouteConfig.RegisterRoutes(RouteTable.Routes);
            CattleTracker.App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExerciseAssiatant
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CheckRoles();
            Utilities.Utilities.CheckSuperUser();
            Utilities.Utilities.CheckClientDefault();
        }

        private void CheckRoles()
        {
            Utilities.Utilities.CheckRoles("Admin");
            Utilities.Utilities.CheckRoles("User");
        }


    }
}

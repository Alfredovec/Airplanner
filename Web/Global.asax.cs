using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Helpers;
using BLL.Managers;
using DAL;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Mvc;
using NLog;
using WebMatrix.WebData;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(Object sender, EventArgs e)
        {
            LoggerHelper.WriteError(HttpContext.Current.Server.GetLastError().Message);
        }

        protected void Application_Start()
        {
            Database.SetInitializer(new DbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebSecurity.InitializeDatabaseConnection("AccountContext", "UserProfile", "UserId", "UserName", true);
            CreateConfiguredUnityContainer();

        }

        private static IUnityContainer CreateConfiguredUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            // (optional) provide default mappings programmatically
            container.RegisterType<IAirplannerManager, AirplannerManager>();
            container.RegisterType<IAirplannerRepository, AirplannerRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // (optional) load static config from the *.xml file
            // container.LoadConfiguration();

            return container;
        }
    }
}

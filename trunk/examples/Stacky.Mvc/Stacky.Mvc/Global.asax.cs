﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stacky.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{api}/{id}", // URL with parameters
                new { controller = "Questions", action = "Active", api = "StackOverflow", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "SODefault", // Route name
                "{controller}/{action}", // URL with parameters
                new { controller = "Questions", action = "Active", api = "StackOverflow", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IT2030_Lab02_Mosinski
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default routing
            routes.MapRoute(
                name: "Default",    // id below must match the name of action paramter, or you can change it. 
                url: "{controller}/{action}/{id}",      // If you change id in Store.Detail(int id) to Store.Details(int num), it would 
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // generate an error; id is an optional paramter
            );
        }
    }
}

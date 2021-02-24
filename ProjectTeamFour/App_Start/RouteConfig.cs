using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectTeamFour
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "",
            //    url: "Projects/GetCategory/{category}-{projectStatus}-{id}", //類型-狀態-各種排序
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional }
            //);

           // routes.MapRoute(
           //    name: "category",
           //    url: "Projects/Index/{category}-{projectStatus}", //類型-狀態-各種排序
           //    defaults: new { controller = "Home", action = "Index", id= UrlParameter.Optional}
           //);
        }
    }
}

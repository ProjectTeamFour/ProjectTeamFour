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
            //車車商城的type action 呈現方式就類似自訂路由，因此不新增find/type 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // 依據產品名稱搜尋的自訂路由，取得商品的邏輯與search相同 
            // "CarCarPlan/Product/產品名稱",
            routes.MapRoute(
                  name: "FindName",
                  url: "CarCarPlan/Product/{id}",
                  defaults: new { controller = "CarCarPlan", action = "FindProjectName", id = UrlParameter.Optional }
              );
            //依據集資類型的自訂路由 - kang
            // "Projects/Category/類型/集資狀態/商品 
            routes.MapRoute(
                   name: "FindProject",
                   url: "Projects/Category/{type}/{projectStatus}/{id}",
                   defaults: new { controller = "Projects", action = "Category", type = UrlParameter.Optional, projectStatus= UrlParameter.Optional, id= UrlParameter.Optional }
               );


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "CarCarPlan", action = "Index", id = UrlParameter.Optional }
           );

           
        }
    }
}

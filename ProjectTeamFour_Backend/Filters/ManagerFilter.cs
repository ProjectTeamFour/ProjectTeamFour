using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ProjectTeamFour_Backend.Filters
{/// <summary>
/// 
/// </summary>
    public class ManagerFilter
    {
        /// <summary>
        /// ManagerAuthroityAttribute類別，繼承 ActionFilter類別
        /// 判斷使用者是否具有最高權限
        /// admin : role = "true"
        /// service : role ="false"
        /// </summary>
        public class ManagerAuthroityAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var manager = context.HttpContext.Request.Cookies.TryGetValue("adm", out string Role);
                if (Role != "True")
                {
                    context.HttpContext.Response.Redirect("/Home/Index");
                }

            }

        }

        /// <summary>
        /// OnActionExecuting – 在執行 Action 之前執行
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {

            var manager = context.HttpContext.Request.Cookies.TryGetValue("R", out string Role);
            if (Role != "True")
            {
                context.HttpContext.Response.Redirect("/Home/Index");
            }
        }

     

    }
}

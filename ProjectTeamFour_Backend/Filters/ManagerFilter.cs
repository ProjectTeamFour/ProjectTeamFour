using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ProjectTeamFour_Backend.Filters
{
    public class ManagerFilter
    {
        public class ValidateModelAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var manager = context.HttpContext.Request.Cookies.TryGetValue("B", out string Role);
                if (Role != "true")
                {
                    context.HttpContext.Response.Redirect("/Home/Index");
                }

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var manager = context.HttpContext.Request.Cookies.TryGetValue("B", out string Role);
            if (Role!= "true")
            {
                context.HttpContext.Response.Redirect("/Home/Index");
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }

    }
}

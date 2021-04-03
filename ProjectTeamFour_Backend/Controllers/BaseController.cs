using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectTeamFour_Backend.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var manager = context.HttpContext.Request.Cookies.TryGetValue("R", out string Role);
            if (Role == "true")
            {
                context.HttpContext.Response.Redirect("./Order/Index");
            }

        }


    }
}

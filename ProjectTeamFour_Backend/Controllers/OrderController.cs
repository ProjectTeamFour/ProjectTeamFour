using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ProjectTeamFour_Backend.Controllers
{
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class OrderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

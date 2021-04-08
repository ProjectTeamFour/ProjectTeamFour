using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Controllers
{
    public class BackendMemberController : Controller
    {
        public IActionResult BackendMemberIndex()
        {
            return View();
        }
    }
}

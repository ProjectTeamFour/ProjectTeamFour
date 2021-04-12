using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProjectTeamFour_Backend.Filters.ManagerFilter;

namespace ProjectTeamFour_Backend.Controllers
{
    public class BackendMemberController : Controller
    {
        // -用filter的話這裡可能要設 [ManagerAuthroity]  Phil
        public IActionResult BackendMemberIndex()
        {
            return View();
        }
    }
}

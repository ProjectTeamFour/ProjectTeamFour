using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Controllers
{
    public class UtiltiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Colors()
        {
            return View();
        }
        public IActionResult Borders()
        {
            return View();
        }
        public IActionResult Animations()
        {
            return View();
        }
        public IActionResult Other()
        {
            return View();
        }

    }
}

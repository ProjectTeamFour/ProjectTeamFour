using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Controllers
{
    public class ManagerController : Controller
    {
        
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginVM)
        {
           
            return View();
        }


    }
}

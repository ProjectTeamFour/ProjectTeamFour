using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using static ProjectTeamFour_Backend.Filters.ManagerFilter;

namespace ProjectTeamFour_Backend.Controllers
{
    /// <summary>
    /// 新增一個 BaseController 
    /// 並在 Controller 掛上 ManagerAuthroity，然後讓其它 Controller 繼承，
    /// 讓所有的 API 受到最基本的權限驗證保護
    /// </summary>
    [ManagerAuthroity]
    public class BaseController : Controller
    {
       


    }
}

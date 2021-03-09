using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using System.IO;
using ProjectTeamFour.Service;
using ProjectTeamFour.Helpers;

namespace ProjectTeamFour.Controllers
{

    public class LogController : Controller
    {
        private LogService _logservice;
        public LogController()
        {
            _logservice = new LogService();
        }
        // GET: Log
        public ActionResult Index()
        {
            LogListViewModel ListViewModel = new LogListViewModel()
            {
                Items = new List<PersonInfoViewModel>()
            };
            foreach(var item in _logservice.GetAll())
            {
                PersonInfoViewModel vm = new PersonInfoViewModel()
                {
                    MemberId=item.MemberId,
                    LogId = item.LogId,
                    DateTime = item.DateTime,
                    //Content = _logservice.Readtext(item.Path)
                };
                ListViewModel.Items.Add(vm);
            }
            return View(ListViewModel.Items);
        }
        [CustomAuthorize(flagNum =1)]
        public ActionResult Test()
        {
            return View();
        }
    }
}
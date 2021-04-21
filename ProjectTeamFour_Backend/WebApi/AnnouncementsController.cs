using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.ViewModels;
using ProjectTeamFour_Backend.Helpers;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        //private readonly CarCarPlanContext _context;
        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnouncementsController> _logger;
        public AnnouncementsController(IAnnouncementService announcementService,ILogger<AnnouncementsController> logger,CarCarPlanContext context)
        {
            _announcementService = announcementService;
            _logger = logger;
        }
        [HttpGet]
        public BaseModel.BaseResult<AnnouncementViewModel.AnnouncementListResult> GetAll()
        {
            var result = new BaseModel.BaseResult<AnnouncementViewModel.AnnouncementListResult>();
            try
            {
                result.Body = _announcementService.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;

                return result;
            }

        }
        [HttpPost]
        public OperationResult CreateAnnouncement(AnnouncementViewModel.AnnouncementVM input)
        {
            
            var User = Request.Cookies["UserEmail"].ToString();
            var result = _announcementService.CreateAnnouncement(input, User);
            return result;
        }
        [HttpPut]
        public OperationResult SaveAnnouncement(AnnouncementViewModel.AnnouncementVM input)
        {
            var User = Request.Cookies["UserEmail"].ToString();
            var result = _announcementService.SaveAnnouncement(input, User);
            return result;
        }
        [HttpDelete]
        public OperationResult DeleteAnnouncement(AnnouncementViewModel.AnnouncementVM input)
        {
            var result = _announcementService.DeleteAnnouncement(input);
            return result;
        }
    }
}

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

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly LabContext _context;
        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnouncementsController> _logger;
        public AnnouncementsController(IAnnouncementService announcementService,ILogger<AnnouncementsController> logger,LabContext context)
        {
            _announcementService = announcementService;
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public BaseModel.BaseResult<AnnouncementViewModel.AnnouncementListResult> GetAll()
        {
            var result = new BaseModel.BaseResult<AnnouncementViewModel.AnnouncementListResult>();
            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "Product控制器GET方法被呼叫");
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
        public async Task<ActionResult<Announcement>> CreateAnnouncement(Announcement input)
        {
            _context.Announcements.Add(input);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAll",new { id = input.AnnouncementId},input);
        }
    }
}

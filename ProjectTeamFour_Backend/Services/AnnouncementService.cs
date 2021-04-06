using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.Repository;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Helpers;

namespace ProjectTeamFour_Backend.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository _dbrepository;

        public AnnouncementService(IRepository repository)
        {
            _dbrepository = repository;
        }


        public AnnouncementViewModel.AnnouncementListResult GetAll()
        {
            AnnouncementViewModel.AnnouncementListResult result = new AnnouncementViewModel.AnnouncementListResult();
            result.MyAnnouncementList = _dbrepository.GetAll<Announcement>().Select(
                a => new AnnouncementViewModel.AnnouncementSingleResult()
                {
                    AnnouncementId = a.AnnouncementId,
                    Content = a.Content,
                    CreateTime = a.CreateTime,
                    CreateUser = a.CreateUser,
                    EditTime = a.CreateTime,
                    EditUser = a.EditUser,
                    MemberId = a.MemberId
                }).ToList();
            return result;
        }
        
        public OperationResult CreateAnnouncement(AnnouncementViewModel.AnnouncementVM input, string editor)
        {
            var result = new OperationResult();
                Announcement announcement = new Announcement
                {
                    Content = input.Content,
                    CreateTime = DateTime.UtcNow.AddHours(8),
                    CreateUser = editor,
                    EditTime = DateTime.UtcNow.AddHours(8),
                    EditUser = editor,
                    MemberId = input.MemberId
                };
                _dbrepository.Create(announcement);
            return result;
        }
    }
}

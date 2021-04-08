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

        public AnnouncementService(IRepository dbrepository)
        {
            _dbrepository = dbrepository;
        }


        public AnnouncementViewModel.AnnouncementListResult GetAll()
        {
            AnnouncementViewModel.AnnouncementListResult result = new AnnouncementViewModel.AnnouncementListResult();
            result.MyAnnouncementList = _dbrepository.GetAll<Announcement>().Select(
                a => new AnnouncementViewModel.AnnouncementSingleResult()
                {
                    AnnouncementId = a.AnnouncementId,
                    Title = a.Title,
                    Content = a.Content,
                    CreateTime = a.CreateTime,
                    CreateUser = a.CreateUser,
                    EditTime = a.EditTime,
                    EditUser = a.EditUser,
                    MemberId = a.MemberId
                }).ToList();
            return result;
        }
        
        public OperationResult CreateAnnouncement(AnnouncementViewModel.AnnouncementVM input, string editor)
        {
            var result = new OperationResult();
            try
            {
                Announcement announcement = new Announcement
                {
                    Content = input.Content,
                    Title = input.Title,
                    CreateTime = DateTime.UtcNow.AddHours(8),
                    CreateUser = editor,
                    EditTime = DateTime.UtcNow.AddHours(8),
                    EditUser = editor,
                    MemberId = input.MemberId
                };
                _dbrepository.Create(announcement);
                result.IsSuccessful = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.IsSuccessful = false;
                return result;
            }
            return result;
        }
        public OperationResult SaveAnnouncement(AnnouncementViewModel.AnnouncementVM input,string editor)
        {
            var result = new OperationResult();
            var data = _dbrepository.GetAll<Announcement>().Where(x => x.AnnouncementId == input.AnnouncementId).FirstOrDefault();
            try
            {
                data.MemberId = input.MemberId;
                data.Content = input.Content;
                data.Title = input.Title;
                data.EditTime = DateTime.UtcNow.AddHours(8);
                data.EditUser = editor;
                _dbrepository.Update(data);
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.IsSuccessful = false;
                return result;
            }
        }

        public OperationResult DeleteAnnouncement(AnnouncementViewModel.AnnouncementVM input)
        {
            var result = new OperationResult();
            var data = _dbrepository.GetAll<Announcement>().Where(x => x.AnnouncementId == input.AnnouncementId).FirstOrDefault();
            try
            {
                _dbrepository.Delete(data);
                return result;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.IsSuccessful = false;
                return result;
            }
        }
    }
}

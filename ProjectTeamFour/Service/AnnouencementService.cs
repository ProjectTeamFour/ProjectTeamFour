using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class AnnouncementService
    {
        private DbContext _context;
        private BaseRepository _repository;
        public AnnouncementService ()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }
        public List<AnnouncementViewModel> GetAnnouncement(int Id)
        {
            var myAnnouncementList = new List<AnnouncementViewModel>();
            var AnnouncementItems = _repository.GetAll<Announcement>().Where(x => x.MemberId == Id || x.MemberId == 235);
            foreach(var item in AnnouncementItems)
            {
                var AnnouncementVM = new AnnouncementViewModel
                {
                    Title = item.Title,
                    Content = item.Content
                };
                myAnnouncementList.Add(AnnouncementVM);
            }
            return myAnnouncementList;
        }
        
    }
}
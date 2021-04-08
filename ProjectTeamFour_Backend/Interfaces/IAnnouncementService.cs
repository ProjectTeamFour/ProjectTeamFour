using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Helpers;
using ProjectTeamFour_Backend.Models;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface IAnnouncementService
    {
        AnnouncementViewModel.AnnouncementListResult GetAll();
        OperationResult CreateAnnouncement(AnnouncementViewModel.AnnouncementVM input, string editor);
        OperationResult SaveAnnouncement(AnnouncementViewModel.AnnouncementVM input, string editor);
        OperationResult DeleteAnnouncement(AnnouncementViewModel.AnnouncementVM input);
    }
}

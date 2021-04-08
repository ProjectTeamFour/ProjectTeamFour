using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Interfaces
{
   public interface IMemberService
    {
        Task <MemberViewModel.MemberListResult> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface IBackendMemberService
    {
        BackendMemberViewModel.BackendListResult GetAll();
        BackendMemberViewModel.BackendSingleResult CreateOneMember(BackendMemberViewModel.BackendSingleResult singleMember);

        BackendMemberViewModel.BackendSingleResult GetOne(int id);
        string EditMember(BackendMemberViewModel.BackendSingleResult singleMember);
    }
}

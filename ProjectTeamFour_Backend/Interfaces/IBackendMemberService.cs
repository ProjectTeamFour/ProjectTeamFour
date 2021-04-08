using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface IBackendMemberService
    {
        //BackendMemberViewModel.BackendListResult GetAll();
        //BackendMemberViewModel.BackendSingleResult CreateOneMember(BackendMemberViewModel.BackendSingleResult singleMember);

        //BackendMemberViewModel.BackendSingleResult GetOne(int id);
        //string EditMember(BackendMemberViewModel.BackendSingleResult singleMember);

        //string DeleteMember(BackendMemberViewModel.BackendSingleResult singleMember);
        BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult> GetBackendAuthentication(LoginViewModel loginVM);
        Task<BackendMemberViewModel.BackendListResult> GetAll();
        Task<BackendMemberViewModel.BackendSingleResult> CreateOneMember(BackendMemberViewModel.BackendSingleResult singleMember);

        Task<BackendMemberViewModel.BackendSingleResult> GetOne(int id);
        Task<string>  EditMember(BackendMemberViewModel.BackendSingleResult singleMember);

        Task<string> DeleteMember(BackendMemberViewModel.BackendSingleResult singleMember);
    }
}

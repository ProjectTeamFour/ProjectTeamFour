using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Services
{
    public class MemberService: IMemberService
    {
        private readonly IRepository _dbRepository;

        public MemberService(IRepository repository)
        {
            _dbRepository = repository;
        }

        public Task<MemberViewModel.MemberListResult> GetAll()
        {
            return Task.Run(() =>
            {
                MemberViewModel.MemberListResult result = new MemberViewModel.MemberListResult();
                result.MemberList = _dbRepository.GetAll<Member>().Select(
                    m => new MemberViewModel.MemberSingleResult()
                    {

                        MemberAddress = m.MemberAddress,
                        MemberBirth = m.MemberBirth.ToString("d"),
                        MemberConEmail = m.MemberConEmail,
                        MemberId = m.MemberId,
                        MemberName = m.MemberName,
                        MemberPhone = m.MemberPhone,
                        MemberRegEmail = m.MemberRegEmail,
                        MemberWebsite = m.MemberWebsite,
                        AboutMe = m.AboutMe,
                        Gender = m.Gender,
                        ProfileImgUrl = m.ProfileImgUrl,
                        MemberTeamName = m.MemberTeamName,

                    }).ToList();
                return result;
            });
           
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Services
{
    public class BackendMemberService : IBackendMemberService
    {
        private readonly IRepository _repository;

        public BackendMemberService(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 從資料庫取得一筆後台會員資料
        /// </summary>
        /// <returns></returns>
        public BackendMemberViewModel.BackendSingleResult GetOne(int id)
        {
            BackendMemberViewModel.BackendSingleResult result = new BackendMemberViewModel.BackendSingleResult();

            var searchResult = _repository.GetAll<Backendmember>().FirstOrDefault(b => b.MemberId == id);

            if(searchResult!=default)
            {
                result.BackendIdentity = searchResult.BackendIdentity;
                result.MemberAccount = searchResult.MemberAccount;
                result.Gender = searchResult.Gender;
                result.MemberAddress = searchResult.MemberAddress;
                result.MemberBirth = searchResult.MemberBirth.ToString("d");
                result.MemberRegEmail = searchResult.MemberRegEmail;
                result.MemberConEmail = searchResult.MemberConEmail;
                result.MemberId = searchResult.MemberId;
                result.MemberMessage = searchResult.MemberMessage;
                result.MemberPhone = searchResult.MemberPhone;
                result.MemberMessage = searchResult.MemberMessage;
                result.MemberName = searchResult.MemberName;

                return result; 
                
            }
            else
            {
                return null;
            }
            

        }
        /// <summary>
        /// 從資料庫取得所有後台會員資料
        /// </summary>
        /// <returns></returns>
        public BackendMemberViewModel.BackendListResult GetAll()
        {
            BackendMemberViewModel.BackendListResult result = new BackendMemberViewModel.BackendListResult();

            result.BackendMemberList = _repository.GetAll<Backendmember>().Select(
                b => new BackendMemberViewModel.BackendSingleResult()
                {
                    MemberId=b.MemberId,
                    MemberName=b.MemberName,
                    MemberAccount=b.MemberAccount,
                    MemberAddress=b.MemberAddress,
                    MemberBirth= b.MemberBirth.ToString("d"),
                    MemberConEmail=b.MemberConEmail,
                    MemberRegEmail=b.MemberRegEmail,
                    MemberPhone=b.MemberPhone,
                    BackendIdentity=b.BackendIdentity,
                    Gender=b.Gender,
                    MemberMessage=b.MemberMessage,
                }).ToList();
            return result;
        }
        /// <summary>
        /// 在資料庫中創建一筆後台會員資料，並返回該筆資料
        /// </summary>
        /// <param name="singleMember"></param>
        /// <returns></returns>
        public BackendMemberViewModel.BackendSingleResult CreateOneMember(BackendMemberViewModel.BackendSingleResult singleMember)
        {
            Backendmember newBackendmember = new Backendmember
            {
                
                MemberName=singleMember.MemberName,
                MemberAccount=singleMember.MemberAccount,
                MemberAddress=singleMember.MemberAddress,
                MemberBirth=DateTime.Parse(singleMember.MemberBirth),
                BackendIdentity=singleMember.BackendIdentity,
                MemberConEmail=singleMember.MemberConEmail,
                MemberRegEmail=singleMember.MemberRegEmail,
                MemberPassword=singleMember.MemberPassword,
                MemberPhone=singleMember.MemberPhone,
            };
            
            _repository.Create(newBackendmember);

            singleMember.MemberId = newBackendmember.MemberId;

            return singleMember;
        }

       
    }
}

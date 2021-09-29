using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Services
{
    public class BackendMemberService : IBackendMemberService
    {
        private readonly IRepository _repository;
        private readonly CarCarPlanContext _labContext;
        public BackendMemberService(IRepository repository,CarCarPlanContext labContext)
        {
            _repository = repository;
            _labContext = labContext;
        }
        /// <summary>
        /// (非同步)在資料庫中創建一筆後台會員資料，並返回該筆資料
        /// </summary>
        /// <param name="singleMember"></param>
        /// <returns></returns>
        public Task<BackendMemberViewModel.BackendSingleResult> CreateOneMember(BackendMemberViewModel.BackendSingleResult singleMember)
        {
            return Task.Run(() =>
            {
                Backendmember newBackendmember = new Backendmember
                {
                    LoginTime = DateTime.UtcNow.AddHours(08),
                    MemberName = singleMember.MemberName,
                    MemberAccount = singleMember.MemberAccount,
                    MemberAddress = singleMember.MemberAddress,
                    MemberBirth = DateTime.Parse(singleMember.MemberBirth),
                    BackendIdentity = singleMember.BackendIdentity,
                    MemberConEmail = singleMember.MemberConEmail,
                    MemberRegEmail = singleMember.MemberRegEmail,
                    MemberPassword = singleMember.MemberPassword,
                    MemberPhone = singleMember.MemberPhone,
                };

                _repository.Create(newBackendmember);

                singleMember.MemberId = newBackendmember.MemberId;

                return singleMember;
            });
        }
        /// <summary>
        /// (非同步)將前端修改後的資料以交易方式，刪除資料庫資料。回傳為字串形式:"查無此筆資料"、"刪除成功"、Exception.Message
        /// </summary>
        /// <param name="singleMember"></param>
        /// <returns></returns>
        public Task<string> DeleteMember(BackendMemberViewModel.BackendSingleResult singleMember)
        {
            return Task.Run(() =>
            {
                var querySingleResult = _repository.GetAll<Backendmember>().FirstOrDefault(B => B.MemberId == singleMember.MemberId);
                if (querySingleResult == default)
                {
                    return "查無此筆資料";
                }

                using (var transaction = _labContext.Database.BeginTransaction())
                {
                    try
                    {
                        _repository.Delete<Backendmember>(querySingleResult);
                        transaction.Commit();
                        return "刪除成功";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();


                        return ex.Message;
                    }
                }
            });
        }
        /// <summary>
        /// (非同步)將前端修改後的資料以交易方式，變更資料庫資料。回傳為字串形式:"查無此筆資料"、"修改成功"、Exception.Message
        /// </summary>
        /// <param name="singleMember"></param>
        /// <returns></returns>
        public Task<string> EditMember(BackendMemberViewModel.BackendSingleResult singleMember)
        {
            return Task.Run(() =>
            {
                var querySingleResult = _repository.GetAll<Backendmember>().FirstOrDefault(B => B.MemberId == singleMember.MemberId);
                if (querySingleResult == default)
                {
                    return "查無此筆資料";
                }
                querySingleResult.BackendIdentity = singleMember.BackendIdentity;
                querySingleResult.MemberAddress = singleMember.MemberAddress;
                querySingleResult.MemberName = singleMember.MemberName;
                querySingleResult.MemberConEmail = singleMember.MemberConEmail;
                querySingleResult.MemberBirth = DateTime.Parse(singleMember.MemberBirth);
                querySingleResult.MemberPhone = singleMember.MemberPhone;

                using (var transaction = _labContext.Database.BeginTransaction())
                {
                    try
                    {
                        _repository.Update<Backendmember>(querySingleResult);
                        transaction.Commit();
                        return "修改成功";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();


                        return ex.Message;
                    }
                }
            });
        }
        /// <summary>
        /// (非同步)從資料庫取得所有後台會員資料
        /// </summary>
        /// <returns></returns>
        public Task<BackendMemberViewModel.BackendListResult> GetAll()
        {
            return Task.Run(() =>
            {
                BackendMemberViewModel.BackendListResult result = new BackendMemberViewModel.BackendListResult();

                result.BackendMemberList = _repository.GetAll<Backendmember>().Select(
                    b => new BackendMemberViewModel.BackendSingleResult()
                    {
                        MemberId = b.MemberId,
                        MemberName = b.MemberName,
                        MemberAccount = b.MemberAccount,
                        MemberAddress = b.MemberAddress,
                        MemberBirth = b.MemberBirth.ToString("d"),
                        MemberConEmail = b.MemberConEmail,
                        MemberRegEmail = b.MemberRegEmail,
                        MemberPhone = b.MemberPhone,
                        BackendIdentity = b.BackendIdentity,
                        Gender = b.Gender,
                        MemberMessage = b.MemberMessage,
                    }).ToList();
                return result;
            });
        }

        public BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult> GetBackendAuthentication(LoginViewModel loginVM)
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();
            var manager = _repository.GetAll<Backendmember>().Where(x => x.MemberRegEmail ==loginVM.MemberRegEmail&& x.MemberPassword==loginVM.Password).FirstOrDefault();
            
            try
            {
                if(manager != null)
                {
                    if (manager.BackendIdentity==true)
                    {
                        result.IsSuccess = true;
                        result.Msg = manager.BackendIdentity.ToString();
                      
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.Msg = manager.BackendIdentity.ToString();
                        
                    }

                   
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                ex.ToString();
            }

            return result;
        }

        /// <summary>
        /// (非同步)從資料庫取得一筆後台會員資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<BackendMemberViewModel.BackendSingleResult> GetOne(int id)
        {
            return Task.Run(() =>
            {
                BackendMemberViewModel.BackendSingleResult result = new BackendMemberViewModel.BackendSingleResult();

                var querySingleResult = _repository.GetAll<Backendmember>().FirstOrDefault(b => b.MemberId == id);

                if (querySingleResult != default)
                {
                    result.BackendIdentity = querySingleResult.BackendIdentity;
                    result.MemberAccount = querySingleResult.MemberAccount;
                    result.Gender = querySingleResult.Gender;
                    result.MemberAddress = querySingleResult.MemberAddress;
                    result.MemberBirth = querySingleResult.MemberBirth.ToString("d");
                    result.MemberRegEmail = querySingleResult.MemberRegEmail;
                    result.MemberConEmail = querySingleResult.MemberConEmail;
                    result.MemberId = querySingleResult.MemberId;
                    result.MemberMessage = querySingleResult.MemberMessage;
                    result.MemberPhone = querySingleResult.MemberPhone;
                    result.MemberMessage = querySingleResult.MemberMessage;
                    result.MemberName = querySingleResult.MemberName;

                    return result;

                }
                else
                {
                    return null;
                }
            });
        }
        



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public class MemberSettingService
    {
        private DbContext _ctx;
        private BaseRepository _repository;
        public MemberSettingService()
        {
            _ctx = new ProjectContext();
            _repository = new BaseRepository(_ctx);
        }
        //依據Id取得該Member的資料
        //public EditMemberViewModel GetMember(int Id)
        public EditMemberViewModel GetMember(Expression<Func<Member, bool>> KeySelector)
        {
            //var entity = _repository.GetAll<Member>().FirstOrDefault(x=>x.MemberId==Id);
            var entity = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
            if(entity!=null)
            {
                var viewModel = new EditMemberViewModel
                {
                    MemberName = entity.MemberName,
                    MemberPassword = entity.MemberPassword,
                    MemberRegEmail = entity.MemberRegEmail,
                    MemberConEmail = entity.MemberConEmail,
                    Gender = entity.Gender,
                    MemberBirth = entity.MemberBirth,
                    AboutMe = entity.AboutMe,
                    ProfileImgUrl = entity.ProfileImgUrl,
                    MemberWebsite = entity.MemberWebsite,
                    MemberMessage = entity.MemberMessage,
                    Permission = entity.Permission
                };
                return viewModel;
            }
            return null;
        }

        public OperationResult Update(EditMemberViewModel input)
        {
            var result = new OperationResult();
            //var result1 = new EditMemberViewModel();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == input.MemberId);
                entity.MemberName = input.MemberName;
                //entity.MemberTeamName = input.MemberTeamName;
                //entity.MemberAccount = input.MemberAccount;
                entity.MemberPassword = input.MemberPassword;
                //entity.MemberAddress = input.MemberAddress;
                //entity.MemberPhone = input.MemberPhone;
                entity.MemberRegEmail = input.MemberRegEmail;
                entity.MemberConEmail = input.MemberConEmail;
                if (input.Gender != "請選擇性別")
                {
                    entity.Gender = input.Gender;
                }
                //entity.MemberBirth = input.MemberBirth;
                entity.AboutMe = input.AboutMe;
                entity.ProfileImgUrl = input.ProfileImgUrl;
                entity.MemberWebsite = input.MemberWebsite;
                entity.MemberMessage = input.MemberMessage;
                _repository.Update(entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                //result.Member
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
                Console.WriteLine(ex);
            }
            return result;
        }
    }
}
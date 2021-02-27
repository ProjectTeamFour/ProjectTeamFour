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
        public EditMemberViewModel GetMember(int Id)
        {
            var entity = _repository.GetAll<Member>().FirstOrDefault(x=>x.MemberId==Id);
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
        

    }
}
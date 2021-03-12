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
using System.Threading.Tasks;
using System.IO;

namespace ProjectTeamFour.Service
{
    public class MemberService
    {
        private DbContext _context;
        private BaseRepository _repository;
        public MemberService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }
        //byLambda搜尋
        public MemberViewModel GetMember(Expression<Func<Member, bool>> KeySelector)
        {
            var entity = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
            if (entity != null)
            {
                var viewModel = new MemberViewModel
                {
                    MemberId=entity.MemberId,
                    MemberName = entity.MemberName,
                    MemberTeamName = entity.MemberTeamName,
                    MemberAccount = entity.MemberAccount,
                    MemberPassword = entity.MemberPassword,
                    MemberAddress = entity.MemberAddress,
                    MemberPhone = entity.MemberPhone,
                    MemberRegEmail = entity.MemberRegEmail,
                    MemberConEmail = entity.MemberConEmail,
                    Gender = entity.Gender,
                    MemberBirth = entity.MemberBirth,
                    AboutMe = entity.AboutMe,
                    ProfileImgUrl = entity.ProfileImgUrl,
                    MemberWebsite = entity.MemberWebsite,
                    MemberMessage = entity.MemberMessage,
                    Permission=entity.Permission
                };
                return viewModel;
            }
            return null;
        }
        //全部
        public MemberListViewModel GetMembers()
        {
            var listViewmodel = new MemberListViewModel()
            {
                Items = new List<MemberViewModel>()
            };
            foreach (var entity in _repository.GetAll<Member>())
            {
                var viewModel = new MemberViewModel
                {
                    MemberId = entity.MemberId,
                    MemberName = entity.MemberName,
                    MemberTeamName = entity.MemberTeamName,
                    MemberAccount = entity.MemberAccount,
                    MemberPassword = entity.MemberPassword,
                    MemberAddress = entity.MemberAddress,
                    MemberPhone = entity.MemberPhone,
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
                listViewmodel.Items.Add(viewModel);
            }
            return listViewmodel;
        }
        //新增
        public OperationResult Create(MemberViewModel input)
        {
            var result = new OperationResult();
            try
            {
                Member entity = new Member
                {
                    MemberId=25,
                    MemberName = input.MemberName,
                    MemberTeamName = input.MemberTeamName,
                    MemberAccount = input.MemberAccount,
                    MemberPassword = input.MemberPassword,
                    MemberAddress = input.MemberAddress,
                    MemberPhone = input.MemberPhone,
                    MemberRegEmail = input.MemberRegEmail,
                    MemberConEmail = input.MemberConEmail,
                    Gender = input.Gender,
                    MemberBirth = input.MemberBirth,
                    AboutMe = input.AboutMe,
                    ProfileImgUrl = input.ProfileImgUrl,
                    MemberWebsite = input.MemberWebsite,
                    MemberMessage = input.MemberMessage,
                    Permission=input.Permission
                };
                _repository.Create(entity);
                result.IsSuccessful = true;
            }
            catch(Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
            }
            return result;
        }
        //修改    
        public OperationResult Update(EditMemberViewModel input)
        {
            var result = new OperationResult();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == input.MemberId);
                entity.MemberName = input.MemberName;
                entity.MemberConEmail = input.MemberConEmail;
                if (input.Gender != "請選擇性別")
                {
                    entity.Gender = input.Gender;
                }
                //entity.MemberBirth = input.MemberBirth;
                entity.AboutMe = input.AboutMe;
                entity.ProfileImgUrl = input.ProfileImgUrl;
                entity.MemberWebsite = input.MemberWebsite;
                entity.ProfileImgUrl = input.ProfileImgUrl;
                _repository.Update(entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                //result.Member
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
            }
            return result;
        }
        public OperationResult Delete(int MemberId)
        {
            var result = new OperationResult();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == MemberId);
                _repository.Delete(entity);
            }catch(Exception ex)
            {
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
            }
            return result;
        }
        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null)
            {
                return 0;
            }
            return ((MemberViewModel)session["Member"]).MemberId;
        }
        public void Relogin()
        {
            var session = HttpContext.Current.Session;
            int id= ((MemberViewModel)session["Member"]).MemberId;
             session["Member"] = GetMember(p=>p.MemberId==id);
        }

        


    }      
}
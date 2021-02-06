using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Reposities;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class MemberService
    {
        private BaseReposity<Member> _baseReposity;
        public MemberService()
        {
            DbContext dbcontext = new ProjectContext();
            _baseReposity = new BaseReposity<Member>(dbcontext);
        }
        public Member GetMember(int id)
        {
            var members= _baseReposity.GetAll();
            Member m = members.FirstOrDefault(p => p.MemberId == id);
            return m;
        }
        public Member GetMember(string account,string pwd)
        {
            var members = _baseReposity.GetAll();
            Member m = members.FirstOrDefault(p => p.Account == account && p.PassWord == pwd);
            return m;
        }

        public List<Member> GetMembers()
        {
            return _baseReposity.GetAll().ToList();
        }
        public string CreateMember(ViewMembers vm)
        {
            string Message = "";
            try
            {
                Member m = new Member();
                m.Account = vm.Account;
                m.PassWord = vm.PassWord;
                m.Name = m.Name;
                  _baseReposity.Create(m);

                Message = "新增成功";
            }
            catch (Exception ex)
            {
                Message = ex.ToString();
            }
            return Message;
        }
    }
}
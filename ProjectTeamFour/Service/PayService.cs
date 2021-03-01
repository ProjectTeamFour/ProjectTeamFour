using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;


namespace ProjectTeamFour.Service
{
    public class PayService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public PayService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public PayViewModel QueryMemberId(int Id) //憑會員Id找會員資料
        {
            var member = _repository.GetAll<Member>().FirstOrDefault((x) => x.MemberId == Id);

            if(member == null)
            {
                return new PayViewModel();
            }
            else
            {
                var memberList = new PayViewModel()
                {
                    MemberName = member.MemberName,
                    MemberAddress = member.MemberAddress,
                    MemberPhone = member.MemberPhone,
                    MemberConEmail = member.MemberConEmail
                };
                return memberList;
            }
            
        }
        
        public PayViewModel QueryByPlanId(int Id) //撈資料庫資料 用購物車的planId找到資料庫的planId
        {
            var plan = _repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == Id);


            if (plan == null) //如果沒抓到這個iD
            {
                return new PayViewModel();
            }

            var listviewmodel = new PayViewModel()
            {
                PlanCardItems = new List<SelectPlanViewModel>()
            };
            foreach(var item in _repository.GetAll<Plan>())
            {
                var viewmodel = new SelectPlanViewModel
                {
                    PlanPrice = item.PlanPrice,
                    PlanImgUrl = item.PlanImgUrl,
                    PlanTitle = item.PlanTitle,
                };
                listviewmodel.PlanCardItems.Add(viewmodel);
            }

            return listviewmodel;
        }      

        public PayViewModel GetPlanById(int Id)  //憑PlanId找其他資料
        {
            var planId = QueryByPlanId(Id);

            return planId;
        }

        public PayViewModel GetMemberById(int Id)
        {
            var memberId = QueryMemberId(Id);

            return memberId;
        }

       
    }
}
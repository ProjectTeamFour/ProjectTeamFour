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
        
        public PayViewModel QueryByPlanId(CartItemListViewModel cart) //撈資料庫資料 用購物車的planId找到資料庫的planId
        {
            var listviewmodel = new PayViewModel()
            {
                CartItems = new List<CarCarPlanViewModel>()
            };

            foreach (var item in cart.CartItems) //先撈session
            {
                var plan = _repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == item.PlanId); //資料庫id==sessionId

                foreach (var items in listviewmodel.CartItems) //再撈資料庫
                {
                    var viewmodel = new CarCarPlanViewModel
                    {
                        PlanId= plan.PlanId,
                        Quantity= item.Quantity,
                        PlanPrice = plan.PlanPrice,
                        PlanImgUrl = plan.PlanImgUrl,
                        PlanTitle = plan.PlanTitle,
                        ProjectId = plan.ProjectId
                    };
                    listviewmodel.CartItems.Add(viewmodel);
                };                
            }
            return listviewmodel;
        }      

        //public PayViewModel GetPlanById(CartItemListViewModel cart)  //憑PlanId找其他資料
        //{
        //    var planId = QueryByPlanId(cart);

        //    return planId;
        //}

        public PayViewModel GetMemberById(int Id)
        {
            var memberId = QueryMemberId(Id);

            return memberId;
        }                           
    }
}
using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;

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

        //public PayViewModel QueryMemberId(Expression<Func<Member, bool>> KeySelector) //憑會員Id找會員資料
        //{
            
        //    var member = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
            
        //    if (member != null)
        //    {
        //        var memberList = new PayViewModel()
        //        {
        //            MemberName = member.MemberName,
        //            MemberAddress = member.MemberAddress,
        //            MemberPhone = member.MemberPhone,
        //            MemberConEmail = member.MemberConEmail
        //        };
        //        return memberList;
        //    }
        //    return null;                               
        //}
        
        public PayViewModel QueryByPlanId(CartItemListViewModel cart) //撈資料庫資料 用購物車的planId找到資料庫的planId
        {

            
            var listviewmodel = new PayViewModel()
            {
                CartItems = new List<CarCarPlanViewModel>()
            };

            foreach (var item in cart.CartItems) //先撈session
            {
                var session = HttpContext.Current.Session;
                var member123 = ((MemberViewModel)session["Member"]);
                var plan = _repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == item.PlanId); //資料庫id==sessionId
                var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == member123.MemberId);
                
                var viewmodel = new PayViewModel
                {
                    MemberName = member.MemberName,
                    MemberAddress = member.MemberAddress,
                    MemberPhone = member.MemberPhone,
                    MemberConEmail = member.MemberConEmail,
                    MemberId = member.MemberId,
                    CartItems = new List<CarCarPlanViewModel>
                    {
                        new CarCarPlanViewModel {
                            PlanId = plan.PlanId,
                            Quantity = item.Quantity,
                            PlanPrice = plan.PlanPrice,
                            PlanImgUrl = plan.PlanImgUrl,
                            PlanTitle = plan.PlanTitle,
                            ProjectId = plan.ProjectId
                        }
                    },
                };
                return viewmodel;                                                                                   
            }            
            return listviewmodel;
        }      

        //public PayViewModel GetPlanById(CartItemListViewModel cart)  //憑PlanId找其他資料
        //{
        //    var planId = QueryByPlanId(cart);

        //    return planId;
        //}

        //public PayViewModel GetMemberById(int Id)
        //{
        //    var memberId = QueryMemberId(Id);

        //    return memberId;
        //}

        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null ||session["Cart"]==null)
            {
                return 0;
            }

            var x = ((MemberViewModel)session["Member"]);
            return ((MemberViewModel)session["Member"]).MemberId;
        }
    }
}
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
        
        public PayViewModel QueryByPlanId(CartItemListViewModel cart) //撈資料庫資料 用購物車的planId找到資料庫的planId
        {

            
            //var listviewmodel = new PayViewModel()
            //{
            //    CartItems = new List<CarCarPlanViewModel>()
            //};
            var session = HttpContext.Current.Session;
            var memberSession = ((MemberViewModel)session["Member"]);
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == memberSession.MemberId);

            var viewmodel = new PayViewModel
            {
                MemberName = member.MemberName,
                MemberAddress = member.MemberAddress,
                MemberPhone = member.MemberPhone,
                MemberConEmail = member.MemberConEmail,
                MemberId = member.MemberId,
                CartItems = new List<CarCarPlanViewModel>() //先給他一個空的集合 讓viewmodel知道我需要這筆資料
            };

            foreach (var item in cart.CartItems) //先撈session
            {                                
                var plan = _repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == item.PlanId); //資料庫id==sessionId 之後要移出foreach          

                var CartItem = new CarCarPlanViewModel
                {                    
                    PlanId = plan.PlanId,
                    Quantity = item.Quantity,
                    PlanPrice = plan.PlanPrice,
                    PlanImgUrl = plan.PlanImgUrl,
                    PlanTitle = plan.PlanTitle,
                    ProjectId = plan.ProjectId                    
                };
                viewmodel.CartItems.Add(CartItem);                                                                            
            }
            return viewmodel;
        }    
        
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
        //回傳訂單資料給資料庫
        public void CreateOrderToDB(CarCarPlanViewModel cartPlan) //把購物車的資料&member回傳給資料庫
        {
            var session = HttpContext.Current.Session;
            var memberSession = ((MemberViewModel)session["Member"]);
            var cartSession = ((CartItemListViewModel)session["Cart"]);
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == memberSession.MemberId); //從會員資料庫抓
            var cart = cartSession.CartItems.Where(x => x.PlanId == cartPlan.PlanId).Select(x => x).FirstOrDefault(); //從session抓
            var plan = _repository.GetAll<Plan>().Where((x) => x.ProjectId == cartPlan.ProjectId).Select((X) => X).FirstOrDefault(); //從PLAN資料庫抓
                                                                                                                                     //製作order資料  把其他viewmodel資料指派給order    

            var order = new PayViewModel
            {
                OrderName = member.MemberName,
                OrderAddress = member.MemberAddress,
                OrderPhone = member.MemberPhone,
                OrderConEmail = member.MemberConEmail,
                OrderItems = new List<OrderDetail>()
            };
            foreach(var item in order.OrderItems)
            {
                var orderitem = new OrderDetail
                {
                    PlanTitle = plan.PlanTitle,
                    PlanId = plan.PlanId,
                    OrderPrice = plan.PlanPrice,
                    OrderQuantity = cart.Quantity,
                    OrderId = order.OrderId,
                };
                order.OrderItems.Add(orderitem);
            }
            _repository.Create(order);


            //var order = new Order
            //{
            //    MemberId = member.MemberId,
            //    OrderName = member.MemberName,
            //    OrderAddress = member.MemberAddress,
            //    OrderPhone = member.MemberPhone,
            //    OrderConEmail = member.MemberConEmail,
            //};
            //var orderlist = new List<OrderDetail>
            //{
            //     order = new OrderDetail
            //     {
            //         PlanTitle = plan.PlanTitle,
            //         PlanId = plan.PlanId,
            //         OrderPrice = plan.PlanPrice,
            //         OrderQuantity = cart.Quantity,
            //         OrderId = order.OrderId,
            //     }                 
            //};
            //orderlist.Add();
            //_repository.Create(order);
            //_repository.Create(orderlist);

        }
    }
}
using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;
using ECPay.Payment.Integration;
using System.Collections;
using ProjectTeamFour.ViewModels.ForMemberView;

namespace ProjectTeamFour.Service
{
    public class BackingService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public System.Web.HttpResponse Response { get; }

        public BackingService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }


        public BackingRecordsViewModel QueryOrder(int member) //撈資料庫資料 用登入會員id找order訂單紀錄  畫面資料 == 資料庫資料 先找出現在的memberid => memberid找尋 orderId (foreach) =>再找od
        {
            var session = HttpContext.Current.Session;
            member = ((MemberViewModel)session["Member"]).MemberId; //現在登入的id
            var backorder = new BackingRecordsViewModel();
            var odlist = new List<OrderDetail>();
            var ordermodel = _repository.GetAll<Order>().Where((x) => x.MemberId == member).Select((x) => x).ToList(); //找到匹配memberid的訂單           
            var od = ordermodel.SelectMany(x => x.OrderDetails.Select(y => y)); //訂單的詳細(好幾筆)      //依據為登入的memberId
            foreach (var i in od)
            {
                var order = new OrderDetail()
                {
                    OrderId = i.OrderId,
                    OrderPrice = i.OrderPrice,
                    PlanId = i.PlanId,
                    PlanTitle = i.PlanTitle,
                    OrderQuantity = i.OrderQuantity,
                    OrderDetailDes = i.OrderDetailDes,
                    OrderPlanImgUrl = i.OrderPlanImgUrl,
                    condition = i.condition,
                    Plan = i.Plan
                };
                odlist.Add(order);
            };
            backorder.MyOrderDetailList = odlist;
            backorder.MyOrder = ordermodel;            
            return backorder;                    
        }

        public Order FindOrder(Order i)
        {
            
            var o = _repository.GetAll<Order>().Where(x => x.OrderId == i.OrderId).FirstOrDefault();

            //o.OrderId = i.OrderId;
            //o.OrderName = i.OrderName;
            //o.OrderPhone = i.OrderPhone;
            //o.OrderConEmail = i.OrderConEmail;
            //o.OrderTotalAccount = i.OrderTotalAccount;

            //_repository.Update(o);
            return o;
        }
    }
}                
using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class OrderService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public System.Web.HttpResponse Response { get; }

        public OrderService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public OrderViewModel CatchOrderDb() //撈出資料庫order的全部資料
        {

            var order = new OrderViewModel()
            {
                MyOrder = new List<Order>()
            };

            foreach (var item in _repository.GetAll<Order>())
            {

                Order o = new Order
                {
                    OrderId = item.OrderId,
                    OrderName = item.OrderName,
                    OrderAddress = item.OrderAddress,
                    OrderConEmail = item.OrderConEmail,
                    OrderPhone = item.OrderPhone,
                    OrderTotalAccount = item.OrderTotalAccount,
                    TradeNo = item.TradeNo,
                    condition = item.condition,
                    MemberId = item.MemberId
                };
                order.MyOrder.Add(o);
            }
            return order;
            //return _repository.GetAll<Order>();
        }
    }
}
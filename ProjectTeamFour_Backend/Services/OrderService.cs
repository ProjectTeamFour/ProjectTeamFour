using Microsoft.EntityFrameworkCore;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.Repository;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Services
{
    public class OrderService: IOrderService
    {
        private readonly IRepository _dbRepository; //repository介面
        public  OrderService(IRepository repository) //用dapper方便
        {
            _dbRepository = repository;
        }

        public OrderViewModel.OrderListResult GetAll()
        {
            OrderViewModel.OrderListResult result = new OrderViewModel.OrderListResult();
            result.MyOrderList = _dbRepository.GetAll<Order>().Select(
                o => new OrderViewModel.OrderSingleResult()
                {

                    OrderDetailList = _dbRepository.GetAll<OrderDetail>().Where(x => x.OrderId == o.OrderId).Select(x => new OrderDetail
                    {
                        PlanTitle = x.PlanTitle,
                        OrderPrice = x.OrderPrice,
                        OrderQuantity = x.OrderQuantity,
                        OrderDetailId = x.OrderDetailId,
                        Condition = x.Condition,
                        OrderPlanImgUrl = x.OrderPlanImgUrl,
                        PlanId = x.PlanId,
                        OrderDetailDes = x.OrderDetailDes,
                        ProjectId = x.ProjectId
                    }).ToList(),
                    OrderAddress = o.OrderAddress,
                    OrderConEmail = o.OrderConEmail,
                    OrderId = o.OrderId,
                    OrderName = o.OrderName,
                    OrderTotalAccount = o.OrderTotalAccount,
                    OrderPhone = o.OrderPhone,
                    Condition = o.Condition,
                    TradeNo = o.TradeNo,
                    MemberId = o.MemberId,                    
                }).ToList();
            return result;
        }
    }     
}

using Microsoft.AspNetCore.Mvc;
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
        private readonly CarCarPlanContext _context; 

        public  OrderService(IRepository repository, CarCarPlanContext context) //用dapper方便
        {
            _dbRepository = repository;
            _context = context;
        }

        public Task<OrderViewModel.OrderListResult> GetAll()
        {
            return Task.Run(() =>
            {                
                OrderViewModel.OrderListResult result = new OrderViewModel.OrderListResult();                
                result.MyOrderList = _dbRepository.GetAll<Order>().Select(
                    o => new OrderViewModel.OrderSingleResult()
                    {//plan的planId==orderdetail 的 planId  滿足這個條件後的planDate 要等於 orderdetail的planshipDate 
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
                            ProjectId = x.ProjectId,                     
                        }).ToList(),
                        OrderAddress = o.OrderAddress,
                        OrderConEmail = o.OrderConEmail,
                        OrderId = o.OrderId,
                        OrderName = o.OrderName,
                        OrderTotalAccount = o.OrderTotalAccount,
                        OrderPhone = o.OrderPhone,
                        OrderDate = o.OrderDate.Date.ToString("d"),
                        Condition = o.Condition,
                        TradeNo = o.TradeNo,
                        MemberId = o.MemberId,
                    }).ToList();
                return result;
            });
        }


        //Delete單筆                         
        public Task<string> DeleteOrder(OrderViewModel.OrderSingleResult order)
        {
            return Task.Run(() =>
            {
                var singleOrder = _dbRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == order.OrderId);
                if (singleOrder == null)
                {
                    return "查無此匹配訂單";
                }
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {

                        _dbRepository.Delete(singleOrder);
                        transaction.Commit();
                        return "刪除成功";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return ex.Message;
                    }
                }
            });                         
        }
        public Task<string> UpdateOrder(OrderViewModel.OrderSingleResult orderUpdate)
        {
            return Task.Run(() =>
            {
                //從資料庫抓資料單筆
                var singleOrder = _dbRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == orderUpdate.OrderId);
                if (singleOrder == null)
                {
                    return "無匹配訂單";
                }
                else
                {
                    singleOrder.OrderName = orderUpdate.OrderName;
                    singleOrder.OrderPhone = orderUpdate.OrderPhone;
                    singleOrder.OrderConEmail = orderUpdate.OrderConEmail;
                    singleOrder.Condition = orderUpdate.Condition;
                    singleOrder.OrderAddress = orderUpdate.OrderAddress;
                }
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _dbRepository.Update(singleOrder);
                        transaction.Commit();
                        return "更新成功";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return ex.Message;
                    }
                }
            });           
        }
    }     
}

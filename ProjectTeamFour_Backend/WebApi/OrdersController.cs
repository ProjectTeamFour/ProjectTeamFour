using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.Services;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<BaseModel.BaseResult<OrderViewModel.OrderListResult>>> GetAll()
        {
            var result = new BaseModel.BaseResult<OrderViewModel.OrderListResult>();
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器Get方法被呼叫, by" + UriHelper.GetDisplayUrl(Request)); //確認前後參數是否一致
            try
            {
                result.Body = await _orderService.GetAll();
                return result;
            }
            catch(Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }
        }

        // GET: api/Orders/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> GetOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return order;
        //}

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async  Task<ActionResult<BaseModel.BaseResult<OrderViewModel.OrderSingleResult>>> UpdateOrder([FromBody] OrderViewModel.OrderSingleResult orderSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器PUT方法被呼叫-傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(orderSingle));

            var result = new BaseModel.BaseResult<OrderViewModel.OrderSingleResult>();
            var updateOrder =await _orderService.UpdateOrder(orderSingle);

            result.Msg = updateOrder;
            if(result.Msg == "查無此筆訂單")
            {
                result.IsSuccess = false;
                return result;
            }
            else if(result.Msg == "更新成功")
            {
                result.IsSuccess = true;
                return result;
            }
            else
            {
                result.IsSuccess = false;
                return result;
            }
        }

        //// DELETE: api/Orders/5
        [HttpDelete]
        public async Task<ActionResult<BaseModel.BaseResult<OrderViewModel.OrderSingleResult>>> DeleteOrder([FromBody] OrderViewModel.OrderSingleResult orderSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器Delete方法被呼叫, by" + UriHelper.GetDisplayUrl(Request)); //確認前後端參數是否一致
            var result = new BaseModel.BaseResult<OrderViewModel.OrderSingleResult>(); //刪除單一筆資料
            var deleteOrder = await _orderService.DeleteOrder(orderSingle);
            
            result.Msg = deleteOrder; //刪除成功 或 錯誤訊息
            if(result.Msg == "無匹配訂單")
            {
                result.IsSuccess = false;
                return result;
            }
            else if(result.Msg == "刪除成功")
            {
                result.IsSuccess = true;
                return result;
            }
            else
            {
                result.IsSuccess = false;
                return result;
            }            
        }
    }
}

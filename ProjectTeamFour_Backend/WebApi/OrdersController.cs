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
        public BaseModel.BaseResult<OrderViewModel.OrderListResult> GetAll()
        {
            var result = new BaseModel.BaseResult<OrderViewModel.OrderListResult>();
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器Get方法被呼叫, by" + UriHelper.GetDisplayUrl(Request)); //確認前後參數是否一致
            try
            {
                result.Body = _orderService.GetAll();
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
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器PUT方法被呼叫-傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(order));
        //    if (id != order.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Orders
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Order>> PostOrder([FromBody]Order order)
        //{
        //    _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器Post方法被呼叫-傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(order));

        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        //}

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器Delete方法被呼叫, by" + UriHelper.GetDisplayUrl(Request)); //確認前後端參數是否一致
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.OrderId == id);
        //}
    }
}

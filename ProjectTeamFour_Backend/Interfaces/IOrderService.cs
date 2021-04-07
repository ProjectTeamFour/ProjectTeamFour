using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel.OrderListResult> GetAll();
        Task<string> DeleteOrder(OrderViewModel.OrderSingleResult order);

        Task<string> UpdateOrder(OrderViewModel.OrderSingleResult orderUpdate);
    }
}

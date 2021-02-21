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
    public class CartService
    {
        private DbContext _ctx;

        private BaseRepository repository;

        public CartService()
        {
            _ctx = new ProjectContext();
            repository = new BaseRepository(_ctx);
        }

        public CarCarPlanViewModel QueryByPlanId(int Id)
        {
            var plan = repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == Id);
            

            if (plan == null)
            {
                return new CarCarPlanViewModel();
            }

            var cartItem = new CarCarPlanViewModel
            {
                PlanId = plan.PlanId,
                PlanTitle = plan.PlanTitle,
                PlanPrice=plan.PlanPrice,
                PlanImgUrl=plan.PlanImgUrl,
               
                Quantity=1
                
            };
            return cartItem;

        }

        public CarCarPlanViewModel GetPlanById(int Id)
        {
            var plan = QueryByPlanId(Id);

            return plan;
        }


    }
}
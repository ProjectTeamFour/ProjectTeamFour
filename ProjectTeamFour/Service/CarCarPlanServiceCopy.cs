using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class CarCarPlanServiceCopy
    {
        private DbContext _context;
        private BaseRepository _repository;

        public CarCarPlanServiceCopy()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }


        public List<Plan> GetCarCarPlans()
        {
            var planInDB = new List<Plan>();

            try
            {
                planInDB = _repository.GetAll<Plan>()
                    .Where(Plan => Plan.AddCarCarPlan == true).//Select
                    .ToList();    
                //取得
            }
            catch(Exception ex)
            {

            }
            return planInDB;
        }
    }
}

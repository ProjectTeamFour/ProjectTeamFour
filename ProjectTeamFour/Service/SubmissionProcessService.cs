using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class SubmissionProcessService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public SubmissionProcessService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }


        public OperationResult ReceiveSubmissionData(SubmissionProcessViewModel input)
        {
            //SubmissionProcessViewModel SPVM = new SubmissionProcessViewModel();

            var result = new OperationResult();

            

            try
            {
                Project pr_entity = new Project
                {
                    ProjectName = input.ProjectName,
                    AmountThreshold = input.AmountThreshold,
                    Category = input.Category,
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    ProjectVideoUrl = input.ProjectVideoUrl,
                    ProjectMainUrl = input.ProjectMainUrl,
                    ProjectCoverUrl = input.ProjectCoverUrl,
                    //ProjectPrincipal
                    //IdentityNumber
                    CreatorName = input.CreatorName,
                    ProjectImgUrl = input.ProjectImgUrl,
                    
                };
                _repository.Create(pr_entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                return result;
            }
            try
            {

                Member m_entity = new Member
                {
                    MemberConEmail = input.MemberConEmail,
                    MemberPhone = input.MemberPhone,
                    ProfileImgUrl = input.ProfileImgUrl,
                    AboutMe = input.AboutMe,
                    MemberWebsite = input.MemberWebsite,
                };
                _repository.Create(m_entity);
                result.IsSuccessful = true;

            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                return result;
            }
            try
            {
                Plan pl_entity = new Plan
                {
                    //ProjectPlanId = input.ProjectPlanId,
                    //PlanPrice = input.PlanPrice,
                    //PlanTitle = input.PlanTitle,
                    //QuantityLimit = input.QuantityLimit,
                    ////AddCarCarPlan
                    //PlanDescription = input.PlanDescription,
                    //PlanImgUrl = input.PlanImgUrl,
                    ////PlanShipDate
                };
                _repository.Create(pl_entity);
                result.IsSuccessful = true;

            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                return result;
            }

            return result;

        }
    }
}
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface IProjectService
    {
        /// <summary>
        /// 取得所有提案
        /// </summary>
        /// <returns></returns>
        Task<ProjectViewModel.ProjectListResult> GetAll();

        /// <summary>
        /// 依類別查詢提案
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ProjectViewModel.ProjectListResult> GetByCategory(ProjectViewModel.GetByCategoryRequest request);

        /// <summary>
        /// 依Id查詢商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ProjectViewModel.ProjectSingleResult> GetById(ProjectViewModel.GetByIdRequest request);

        Task<ProjectViewModel.ProjectListResult> GetTotalSale();


        Task<ProjectViewModel.ProjectListResult> GetWaitForPass();


        public Task<string> EditWaitForPassProject(ProjectViewModel.ProjectSingleResult waitForPassProject);

        Task<ProjectViewModel.ProjectListforChart> GetAllForCharts();
    }
}

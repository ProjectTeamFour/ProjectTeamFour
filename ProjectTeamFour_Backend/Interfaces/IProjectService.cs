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
        ProjectViewModel.ProjectListResult GetAll();

        /// <summary>
        /// 依類別查詢提案
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ProjectViewModel.ProjectListResult GetByCategory(ProjectViewModel.GetByCategoryRequest request);

        /// <summary>
        /// 依Id查詢商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ProjectViewModel.ProjectSingleResult GetById(ProjectViewModel.GetByIdRequest request);

        ProjectViewModel.ProjectListResult GetTotalSale();


        ProjectViewModel.ProjectListResult GetWaitForPass();


        String EditWaitForPassProject(ProjectViewModel.ProjectSingleResult request);


    }
}

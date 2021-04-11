using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectTeamFour_Backend.ViewModels
{
    public class CarCarPlanViewModel
    {
        public class CarCarPlanBaseViewModel
        {
            /// <summary>
            /// 方案唯一識別碼
            /// </summary>
            [Required]
            public int PlanId { get; set; }
            /// <summary>
            /// 方案於提案內的序列
            /// </summary>
            public int ProjectPlanId { get; set; }
            /// <summary>
            /// 是否進入車車商城
            /// </summary>
            public bool AddCarCarPlan { get; set; }
            /// <summary>
            /// 對應提案名稱
            /// </summary>
            public string ProjectName { get; set; }
            /// <summary>
            /// Foreign Key
            /// </summary>
            public int ProjectId { get; set; }
            /// <summary>
            /// 方案名稱
            /// </summary>
            public string PlanTitle { get; set; }
            /// <summary>
            /// 方案贊助人數
            /// </summary>
            public int PlanFundedPeople { get; set; }
            /// <summary>
            /// 方案預估寄送時間
            /// </summary>
            public string PlanShipDate { get; set; }

            public DateTime DateTimePlanShipDate {get;set;}
            /// <summary>
            /// 方案詳述
            /// </summary>
            public string PlanDescription { get; set; }
            /// <summary>
            /// 方案圖片連結
            /// </summary>
            public string PlanImgUrl { get; set; }
            /// <summary>
            /// 方案價錢
            /// </summary>
            public decimal PlanPrice { get; set; }
            /// <summary>
            /// 方案庫存
            /// </summary>
            public int QuantityLimit { get; set; }
            /// <summary>
            /// 提案者發起修改庫存
            /// </summary>
            public int? SubmitLimit { get; set; }


        }
        /// <summary>
        /// 取得多種車車商城方案模型
        /// </summary>
        public class CarCarPlanListResult
        {
            public List<CarCarPlanSingleResult> CarCarPlanList { get; set; }
        }

        /// <summary>
        /// 取得單一車車商城方案模型
        /// </summary>
        public class CarCarPlanSingleResult : CarCarPlanBaseViewModel
        {

        }



        public class SelectPlanViewModel
        {
            public int PlanId { get; set; }
            public int ProjectPlanId { get; set; }

            public int ProjectId { get; set; }
            public string PlanTitle { get; set; }
            public int PlanFundedPeople { get; set; }
            public DateTime PlanShipDate { get; set; }
            public string PlanDescription { get; set; }
            public string PlanImgUrl { get; set; }
            [DataType(DataType.Currency)]
            public decimal PlanPrice { get; set; }
            public int QuantityLimit { get; set; }

        }

        public class PlanListResult
        {
            public List<SelectPlanViewModel> CarCarPlanList { get; set; }
        }
    }
}

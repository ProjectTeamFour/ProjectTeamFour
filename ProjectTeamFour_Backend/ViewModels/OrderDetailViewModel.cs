using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public string OrderDetailDes { get; set; }
        public int OrderId { get; set; }
        public int PlanId { get; set; }
        public string PlanTitle { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        public int ProjectId { get; set; }
        public string OrderPlanImgUrl { get; set; }
        public string Condition { get; set; }
        /// <summary>
        /// 寄送時間
        /// </summary>
        public DateTime PlanShipDate { get; set; }
    }
}

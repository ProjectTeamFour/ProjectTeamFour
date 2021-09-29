using Newtonsoft.Json;
using ProjectTeamFour.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ProjectTeamFour.ViewModels
{
    public class BackingRecordsViewModel
    {
        public List<OrderDetail> MyOrderDetailList { get; set; }

        public List<Order> MyOrder { get; set; }
        
    }
}
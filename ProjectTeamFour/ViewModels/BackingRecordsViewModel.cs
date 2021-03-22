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
        [JsonIgnore()]
        public List<OrderDetail> MyOrderDetailList { get; set; }

        [JsonIgnore()]
        public List<Order> MyOrder { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class ManagerViewModel
    {
        public class ManagerBaseModel
        {       /// <summary>
                /// 管理者ID
                /// </summary>
         public int ManagerID { get; set; }
         /// <summary>
         /// 管理者帳號
         /// </summary>
         public string ManagerName { get; set; }
         /// <summary>
         /// 管理者密碼
         /// </summary>
         public string ManagerPassword { get; set; }
         public bool ManagerRole { get; set; }
                
        }

        public class ManagerListResult
        {
            public List<ManagerSingleResult> ManagerList { get; set; }
        }

        public class ManagerSingleResult : ManagerBaseModel
        {

        }
    }
}

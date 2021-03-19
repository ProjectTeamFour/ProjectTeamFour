using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    /// <summary>
    /// 通用基底
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// WebApi回传模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class BaseResult<T>
        {
            public BaseResult()
            {
                IsSuccess = true;
            }

            /// <summary>
            /// 回传内容物件
            /// </summary>
            public T Body { get; set; }

            /// <summary>
            /// 执行是否成功
            /// </summary>
            public bool IsSuccess { get; set; }

            public string Msg { get; set; }


        }
    }
}

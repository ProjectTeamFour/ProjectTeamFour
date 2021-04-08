using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Helpers
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception Exception { get; set; }
        public string MessageInfo { get; set; }
        public int Status { get; set; }
    }
}

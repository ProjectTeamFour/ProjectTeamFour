using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Api
{
    public class ProjectSubmissionController : ApiController
    {
        private SubmissionProcessService _submissionservice;

        public ProjectSubmissionController()
        {
            _submissionservice = new SubmissionProcessService();
        }
        public string ReceiveData(SubmissionProcessViewModel input)
        {
            var result = new OperationResult();
            result = _submissionservice.ReceiveSubmissionData(input);

            if (result.IsSuccessful)
            {
                return "成功";
            }
            else
            {
                return "失敗";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;
using System.Diagnostics;

namespace ProjectTeamFour.Api
{
    public class ProjectSubmissionController : ApiController
    {
        private SubmissionProcessService _submissionservice;
        private LogService _logservice;

        public ProjectSubmissionController()
        {
            _submissionservice = new SubmissionProcessService();
            _logservice = new LogService();

        }
        public string ReceiveData([FromBody] SubmissionProcessViewModel input)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            var result = new OperationResult();
            int Id = _submissionservice.ReturnLoginnerId();

            sw.Stop();
            Console.WriteLine($"MD5 {sw.ElapsedMilliseconds}ms");

            var first = sw.ElapsedMilliseconds;

            sw.Restart();

            result = _submissionservice.ReceiveSubmissionData(input, Id);

            sw.Stop();
            Console.WriteLine($"SHA1 {sw.ElapsedMilliseconds}ms");

            var second = sw.ElapsedMilliseconds;


            // if(ModelState.IsValid) 前端做
            if (result.IsSuccessful)
            {
                return "成功";
            }
            else
            {
                Log entity = new Log()
                {
                    //Path = result.WriteLog(HostingEnvironment.MapPath("~/Assets/Log/")),
                    DateTime = result.DateTime
                };
                _logservice.Create(entity);
                return "失敗";
            }
        }
    }
}

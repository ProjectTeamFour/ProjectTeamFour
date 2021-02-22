using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Service;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;
using System.Web.Hosting;


using System.Web.Mvc;

namespace ProjectTeamFour.Api
{
    public class MemberApiController : ApiController
    {
        private MemberService _memberService;
        private LogService _logservice;
        public MemberApiController()
        {
            _memberService = new MemberService();
            _logservice = new LogService();
        }
        public MemberViewModel GetMember(Expression<Func<Member, bool>> KeySelector)
        {
            return _memberService.GetMember(KeySelector);
        }
        public MemberListViewModel GetMembers()
        {
            return _memberService.GetMembers();
        }
        //toDO.... HttpResposeMessage.... Request.CreateResponse(HttpStatusCode.OK,)
        public string CreateMember([FromBody] MemberViewModel input)
        {
            // if(ModelState.IsValid) 前端做
            var result = new OperationResult();
            result = _memberService.Create(input);
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
        public string Update([FromBody] MemberViewModel input)
        {
            var result = new OperationResult();
            result = _memberService.Update(input);
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
        public string Delete(int memberid)
        {
            var result = new OperationResult();
            result = _memberService.Delete(memberid);
            if (result.IsSuccessful)
            {
                return "成功";
            }
            else
            {
                Log entity = new Log()
                {
                    //MemberId=result.Member.MemberId,
                    //Path = result.WriteLog(HostingEnvironment.MapPath("~/Assets/Log/")),
                    DateTime = result.DateTime
                };
                _logservice.Create(entity);
                return "失敗";
            }
        }

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Member member = db.Member.Find(id);
        //    db.Member.Remove(member);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public HttpResponseMessage CreateMember([FromBody] ViewMembers vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, ModelState);
        //    }
        //    else
        //    {
        //        string return_str = _memberService.CreateMember(vm);
        //        if (return_str == "新增成功")
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, return_str);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, return_str);
        //        }
        //    }
        //}
    }
}

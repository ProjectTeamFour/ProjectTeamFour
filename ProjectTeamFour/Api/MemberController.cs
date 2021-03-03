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
using Newtonsoft.Json;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Web.Mvc;


namespace ProjectTeamFour.Api
{
    public class MemberApiController : ApiController
    {
        private MemberService _memberService;
        private LogService _logservice;
        private PermissionService _permissionService;
        public MemberApiController()
        {
            _memberService = new MemberService();
            _logservice = new LogService();
            _permissionService = new PermissionService();
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
        public string Update(EditMemberViewModel input)
        {
            var result = new OperationResult();
            result = _memberService.Update(input);
            if (result.IsSuccessful)
            {
                _memberService.Relogin();
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
   
        public string CheckPermission([FromBody]CheckPermissionViewModel input)
        {
            CheckPermissionViewModel cv = _permissionService.CheckPermission(input.MemberId, input.PermissionId);
            return JsonConvert.SerializeObject(cv);
        }
        public string SetPermission([FromBody]CheckPermissionViewModel input)
        {
            return _permissionService.SetPermission(input.MemberId, input.PermissionId, input.Checked);
        }

        public string UploadFiles()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile file = files[0];
            var stream = file.InputStream;
            var myAccount = new Account { ApiKey = "846843815975652", ApiSecret = "qMRPPwm3IgED3Uzefx5CRhz_W7g", Cloud = "dymc0bi31" };
            Cloudinary _cloudinary = new Cloudinary(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream)
            };
            ImageUploadResult uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }


        //public string GetManagerIndex()
        //{
        //    var Members = _memberService.GetMembers();
        //    var Permission = _permissionService.GetPermissions();
        //    var result = new
        //    {
        //        Members = Members,
        //        Permissions = Permission
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        //沒有登入回傳0
        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("MyApi")]
        //public string ReturnMemberId()
        //{
        //    var session = HttpContext.Current.Session;
        //    if (session["Member"] == null)
        //    {
        //        return 0.ToString();
        //    }
        //    return ((MemberViewModel)session["Member"]).MemberId.ToString();
        //}

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Service;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;


namespace ProjectTeamFour.Api
{
    public class MemberController : ApiController
    {
        private MemberService _memberService;
        public MemberController()
        {
            _memberService = new MemberService();
        }
        public Member GetMember(int id)
        {
            return _memberService.GetMember(id);
        }
        public List<Member> GetMembers()
        {
            return _memberService.GetMembers();
        }
        public HttpResponseMessage CreateMember([FromBody]ViewMembers vm)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ModelState);
            }
            else
            {
                string return_str=_memberService.CreateMember(vm);
                if (return_str == "新增成功")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, return_str);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, return_str);
                }
            }
        }
    }
}

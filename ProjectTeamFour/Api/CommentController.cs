﻿using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjectTeamFour.Api
{
    public class CommentController : ApiController
    {
        private readonly CommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentService();
        }
        

        //[System.Web.Mvc.HttpPost]
        public  string UpdateComment([FromBody] CommentViewModel commentVM)
        {
            var session = System.Web.HttpContext.Current.Session;
            
            var member= (MemberViewModel)session["Member"];
            if(member==null)
            {
               
                return "login";
            }
            else if(commentVM.Comment_Question==null)
            {
                return "try";
            }
            else
            {
                commentVM.MemberId = member.MemberId;
                commentVM.Comment_Time = DateTime.Now;
                var result = _commentService.CreateANewComment(commentVM);
                if(result== "success")
                {
                    return "ok";
                }
                else
                {
                    return "fail";
                }
                
            }
            
        }

       
    }
}

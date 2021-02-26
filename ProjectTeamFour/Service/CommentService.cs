using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public class CommentService
    {
        private DbContext _ctx;

        private BaseRepository _repository;

        public CommentService()
        {
            _ctx = new ProjectContext();
            _repository = new BaseRepository(_ctx);
        }

        public Comment GetComment(Expression<Func<Comment, bool>> KeySelector)
        {
            var entity = _repository.GetAll<Comment>().FirstOrDefault(KeySelector);
            if (entity != null)
            { 
                var comments = new Comment
                {
                ProjectId = entity.ProjectId,
                MemberId = entity.MemberId,
                Comment_Question = entity.Comment_Question,
                Comment_Time = entity.Comment_Time,
                Comment_Answer = entity.Comment_Answer
                //public Member Member
                //public Project Project
                };
             return comments;
            }
            return null;
        }
    }
}
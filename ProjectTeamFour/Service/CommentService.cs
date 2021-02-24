using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class CommentService
    {
        private DbContext _ctx;

        private BaseRepository repository;

        public CommentService()
        {
            _ctx = new ProjectContext();
            repository = new BaseRepository(_ctx);
        }
    }
}
using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class AnnouencementService
    {
        private DbContext _context;
        private BaseRepository _repository;
        public AnnouencementService ()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }
        
    }
}
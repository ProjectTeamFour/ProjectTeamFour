using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Reposities;
using ProjectTeamFour.Models;
using System.Data.Entity;

namespace ProjectTeamFour.Service
{
    public class LogService
    {
        private DbContext _context { get; set; }
        private BaseReposity _reposity { get; set; }
        public LogService()
        {
            _context = new ProjectContext();
            _reposity = new BaseReposity(_context);
        }
        //寫入Log檔
        public void Create(Log entity)
        {
            _reposity.Create(entity);
        }
        //取得全部
        public IQueryable<Log> GetAll()
        {
            return _reposity.GetAll<Log>();
        }
        
    }
}
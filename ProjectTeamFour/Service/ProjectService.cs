//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using ProjectTeamFour.Models;
//using ProjectTeamFour.Reposities;

//namespace ProjectTeamFour.Service
//{
//    public class ProjectService
//    {
//        private ProjectContext _context;
//        private BaseReposity<Project> _baseReposity;

//        public ProjectService()
//        {
//            _context = new ProjectContext();
//            _baseReposity = new BaseReposity<Project>(_context); ;
//        }
//        public IEnumerable<Project> getAll()
//        {
//            return _baseReposity.GetAll();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;


namespace ProjectTeamFour_Backend.Services
{
    public class ManagerService 
    {
        private readonly IRepository _dbRepository;

        public ManagerService(IRepository repository)
        {
            _dbRepository = repository;
        }

        








    }
}

using ProjectTeamFour_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Services
{
    public class MemberService: IMemberService
    {
        private readonly IRepository _dbRepository;

        public MemberService(IRepository repository)
        {
            _dbRepository = repository;
        }


        
    }
}

using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
    public class UserSolutionService : IUserSolutionService
    {
        private readonly IUserSolutionRepository _userSolutionRepository;

        public UserSolutionService(IUserSolutionRepository userSolutionRepository)
        {
            _userSolutionRepository = userSolutionRepository;
        }

        public void AddUserSolution(Usersolution usersolution)
        {
           _userSolutionRepository.AddUserSolution(usersolution);
        }

        public Task<Usersolution> getUserSolutionByAssessment(int assessmentId, int userId)
        {
            return _userSolutionRepository.getUserSolutionByAssessment(assessmentId, userId);
        }

        //public Task<List<Usersolution>> getUserSolutionByAssessment()
        //{
        //    return _userSolutionRepository.getUserSolutionByAssessment();
        //}
    }
}

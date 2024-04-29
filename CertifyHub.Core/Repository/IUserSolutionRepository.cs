using CertifyHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Repository
{
    public interface IUserSolutionRepository
    {
        void AddUserSolution(Usersolution usersolution);
        //void getUserSolutionByAssessment(Usersolution usersolution);
        Task<Usersolution> getUserSolutionByAssessment(int assessmentId , int userId);

        // Task<List<Usersolution>> getUserSolutionByAssessment();

    }
}

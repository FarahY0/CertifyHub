using CertifyHub.Core.Common;
using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Repository
{
    public class UserSolutionRepository : IUserSolutionRepository
    {
        private readonly IDbContext _dbContext;

        public UserSolutionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void AddUserSolution(Usersolution usersolution)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", usersolution.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_AssessmentID", usersolution.Assessmentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_QuestionID", usersolution.Questionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_AnswerID", usersolution.Answerid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_UserSolution", usersolution.Usersolutiontext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_AttemptDate", usersolution.Attemptdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
          await  _dbContext.Connection.ExecuteAsync("UserSolutions_Package.AddUserSolution", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<Usersolution> getUserSolutionByAssessment(int assessmentId, int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_AssessmentID", assessmentId, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("p_UserID", userId, dbType: DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Usersolution>("UserSolutions_Package.getUserSolutionByAssessment", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        
    }
}

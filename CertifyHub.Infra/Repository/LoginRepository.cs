using CertifyHub.Core.Common;
using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("USERNAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORD", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLEID", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.CREATE_LOGIN", p, commandType: System.Data.CommandType.StoredProcedure);

        }

        public void DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("LOGIN_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.DELETE_LOGIN", p, commandType: System.Data.CommandType.StoredProcedure);

        }

        public async Task<List<Login>> GetAllLogins()
        {
            var result = await _dbContext.Connection.QueryAsync<Login>("LOGIN_PACKAGE.GET_ALL_LOGINS", commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Login> GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Login>("LOGIN_PACKAGE.GET_LOGIN_BY_ID", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("LOGIN_ID", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORD_", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLE_ID", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USER_ID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.UPDATE_LOGIN", p, commandType: System.Data.CommandType.StoredProcedure);

        }

        public void UpdatePassword(Login login)
        {
            var p = new DynamicParameters();
            p.Add("LOGIN_ID", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NEW_PASSWORD", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.UPDATE_PASSWORD", p, commandType: System.Data.CommandType.StoredProcedure);

        }

        public Login UserLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("USER_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORD", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.USER_LOGIN",
                p, commandType: System.Data.CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public async Task<int> GetInstructorCount()
        {
            
            var parameters = new DynamicParameters();
            parameters.Add("instructor_count", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.GetInstructorCount", parameters, commandType: CommandType.StoredProcedure);

            var count= parameters.Get<int>("instructor_count");
            return count;
        }
        public async Task<int> GetStudentCount()
        {

            var parameters = new DynamicParameters();
            parameters.Add("student_count", DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("LOGIN_PACKAGE.GetStudentCount", parameters, commandType: CommandType.StoredProcedure);

            var count = parameters.Get<int>("student_count");
            return count;
        }
    }
}

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
    public class ProgramRepository : IProgramRepository
    {

        private readonly IDbContext _dbContext;

        public ProgramRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void CreateProgram(Program program)
        {
            var p = new DynamicParameters();
            p.Add("p_TrackName", program.Trackname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", program.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", program.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ProgramPeriod", program.Programperiod, dbType: DbType.String, direction: ParameterDirection.Input);
           await _dbContext.Connection.ExecuteAsync("Program_Package.CreateProgram", p, commandType: CommandType.StoredProcedure);

        }

        public async void DeleteProgram(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ProgramID", id, dbType: DbType.Int32, ParameterDirection.Input);
           await _dbContext.Connection.ExecuteAsync("Program_Package.DeleteProgram", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<Program> GetProgramByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ProgramID", id, dbType: DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetProgramByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public async void UpdateProgram(Program program)
        {
            var p = new DynamicParameters();
            p.Add("p_ProgramID", program.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TrackName", program.Trackname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ProgramPeriod", program.Programperiod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", program.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", program.Description, dbType: DbType.String, direction: ParameterDirection.Input);
           await _dbContext.Connection.ExecuteAsync("Program_Package.UpdateProgram", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Program>> GetAllPrograms()
        {
            var result = await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetAllPrograms", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<List<Program>> GetStudentPrograms(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Program>("Program_Package.GetStudentProgram", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

    }
}

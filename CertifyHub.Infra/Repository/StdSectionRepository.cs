using CertifyHub.Core.Common;
using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
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
    public class StdSectionRepository : IStdSectionRepository
    {
        private readonly IDbContext _dbContext;

        public StdSectionRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stdsection>> GetAllStdSections()
        {
            return (await _dbContext.Connection.QueryAsync<Stdsection>("STD_SECTION_PACKAGE.GET_ALL_STD_SECTIONS", commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task<Stdsection> GetStdSectionById(int id)
        {
            var p = new DynamicParameters();
            p.Add("STD_SECTION_ID", id, DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Stdsection>("STD_SECTION_PACKAGE.GET_STD_SECTION_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Stdsection>> GetStdSectionsBySectionId(int id)
        {
            var p = new DynamicParameters();
            p.Add("SECTION_ID", id, DbType.Int32, ParameterDirection.Input);
            return (await _dbContext.Connection.QueryAsync<Stdsection>("STD_SECTION_PACKAGE.GET_STD_SECTIONS_BY_SECTION_ID", p, commandType: CommandType.StoredProcedure)).ToList();
        }

        public void CreateStdSection(Stdsection stdsection)
        {
            var p = new DynamicParameters();
            p.Add("SECTION_ID", stdsection.Sectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("STUDENT_ID", stdsection.Studentid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("STD_SECTION_PACKAGE.CREATE_STD_SECTION", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStdSection(Stdsection stdsection)
        {
            var p = new DynamicParameters();
            p.Add("STD_SECTION_ID", stdsection.Stdsectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("SECTION_ID", stdsection.Sectionid, DbType.Int32, ParameterDirection.Input);
            p.Add("STUDENT_ID", stdsection.Studentid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("STD_SECTION_PACKAGE.UPDATE_STD_SECTION", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStdSection(int id)
        {
            var p = new DynamicParameters();
            p.Add("STD_SECTION_ID", id, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("STD_SECTION_PACKAGE.DELETE_STD_SECTION", p, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<StdSectionInfo>> GetStdSectionsInfo()
        {
            return (await _dbContext.Connection.QueryAsync<StdSectionInfo>("STD_SECTION_PACKAGE.GET_STD_SECTION_INFO", commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task<int> GetNumberStudentBySectionId(int sectionId)
        {
            var g = new DynamicParameters();
            g.Add("S_SectionID", sectionId, DbType.Int32, ParameterDirection.Input);
            g.Add("student_count", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.QueryAsync("STD_SECTION_PACKAGE.GetNumberStudentBySectionId", g, commandType: CommandType.StoredProcedure);

            return g.Get<int>("student_count");
        }
        public async Task<List<Section>> GetAllSectionNames()
        {
            return (await _dbContext.Connection.QueryAsync<Section>("STD_SECTION_PACKAGE.GetAllSectionNames", commandType: CommandType.StoredProcedure)).ToList();
        }

    }
}

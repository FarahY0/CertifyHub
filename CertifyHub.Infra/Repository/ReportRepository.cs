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
	public class ReportRepository : IReportRepository
	{
		private readonly IDbContext dbContext;
        public ReportRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<AdminReport> GetAdminReports()
        {
            IEnumerable<AdminReport> result = dbContext.Connection.Query<AdminReport>("Report_Package.GetAdminReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        {
            var f = new DynamicParameters();
            f.Add("R_SectionID", SectionID, DbType.Int32, ParameterDirection.Input);
            IEnumerable<InstructorReport> result = dbContext.Connection.Query<InstructorReport>("Report_Package.GetInstructorReport", f, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<LearnerReport>> GetLearnerReport(int UserID, int SectionID)
        {
            var f = new DynamicParameters();
            f.Add("R_StudentID", UserID, DbType.Int32, ParameterDirection.Input);
            f.Add("R_SectionID", SectionID, DbType.Int32, ParameterDirection.Input);
            IEnumerable<LearnerReport> result = dbContext.Connection.Query<LearnerReport>("Report_Package.GetLearnerReport", f, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        //public async Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        //{
        //	var f = new DynamicParameters();
        //	f.Add("R_SectionID", SectionID, DbType.Int32, ParameterDirection.Input);
        //	IEnumerable<InstructorReport> result = dbContext.Connection.Query<InstructorReport>("Report_Package.GetInstructorReport", f, commandType: CommandType.StoredProcedure);

        //	return result.ToList();
        //}
    }
}

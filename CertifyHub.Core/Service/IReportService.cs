using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Service
{
	public interface IReportService
	{
        //public List<LearnerReport> GetLearnerReport();
        Task<List<LearnerReport>> GetLearnerReport(int UserID, int SectionID);
        Task<List<InstructorReport>> GetInstructorReport(int SectionID);

        public List<AdminReport> GetAdminReports();
    }
}

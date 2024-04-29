using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }


        public List<AdminReport> GetAdminReports()
        {
            return reportRepository.GetAdminReports();
        }

        public Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        {
            return reportRepository.GetInstructorReport(SectionID);
        }

        public Task<List<LearnerReport>> GetLearnerReport(int UserID, int SectionID)
        {
            return reportRepository.GetLearnerReport(UserID, SectionID);
        }

        //public Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        //{
        //	return reportRepository.GetInstructorReport(SectionID);
        //}

    }
}

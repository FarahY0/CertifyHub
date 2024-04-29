using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class ReportController : ControllerBase
	{
        private readonly IReportService reportService;
        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }
        //[HttpGet]
        //[Route("GetLearnerReport")]
        //public List<LearnerReport> GetLearnerReport()
        //{
        //	return reportService.GetLearnerReport();
        //}

        [HttpGet]
        [Route("GetLearnerReport/{UserID}/{SectionID}")]
        public Task<List<LearnerReport>> GetLearnerReport(int UserID, int SectionID)
        {
            return reportService.GetLearnerReport(UserID, SectionID);
        }

        [HttpGet]
        [Route("GetInstructorReport/{SectionID}")]
        public Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        {
            return reportService.GetInstructorReport(SectionID);
        }



        [HttpGet]
        [Route("GetAdminReport")]
        public List<AdminReport> GetAdminReport()
        {
            return reportService.GetAdminReports();
        }

        //[HttpGet]
        //[Route("GetInstructorReport/{SectionID}")]
        //public Task<List<InstructorReport>> GetInstructorReport(int SectionID)
        //{
        //	return reportService.GetInstructorReport(SectionID);
        //}


    }
}

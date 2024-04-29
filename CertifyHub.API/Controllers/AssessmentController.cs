using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentService _assessmentService;

        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [HttpGet]
        [Route("AssessmentCountInSection/{sectionId}")]
        public Task<int> CountAssessmentsBySection(int sectionId)
        {
            return _assessmentService.CountAssessmentsBySection(sectionId);
        }

        [HttpGet]
        [Route("AssessmentCountByType/{AssessmentType}")]
        public Task<int> CountAssessmentsByType(string AssessmentType)
        {
            return _assessmentService.CountAssessmentsByType(AssessmentType);
        }

        [HttpPost]
        public void CreateAssessment(Assessment assessment)
        {
            _assessmentService.CreateAssessment(assessment);
        }

        [HttpDelete("{Assessmentid}")]
        public void DeleteAssessment(int Assessmentid)
        {
            _assessmentService.DeleteAssessment(Assessmentid);
        }

        [HttpGet]
        [Route("FilterAssessmentsByDate")]
        public Task<List<Assessment>> FilterAssessmentsByDate(DateTime startDate, DateTime endDate)
        {
            return _assessmentService.FilterAssessmentsByDate(startDate, endDate);
        }

        [HttpGet]
        [Route("GetUpcomingAssessments")]
        public Task<List<Assessment>> GetUpcomingAssessments()
        {
            return _assessmentService.GetUpcomingAssessments();
        }

        [HttpGet]
        [Route("ListAssessmentsByType/{AssessmentType}")]
        public Task<List<Assessment>> ListAssessmentsByType(string AssessmentType)
        {
            return _assessmentService.ListAssessmentsByType(AssessmentType);
        }

        [HttpPut]
        public void UpdateAssessment(Assessment assessment)
        {
            _assessmentService.UpdateAssessment(assessment);
        }

    }
}

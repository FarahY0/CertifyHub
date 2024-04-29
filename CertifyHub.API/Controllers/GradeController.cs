using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        [Route("CalculateUserGrade/{userid}")]
        public Task<double> CalculateUserGrade(int userid)
        {
            return _gradeService.CalculateUserGrade(userid);
        }

        [HttpGet]
        [Route("ConvertToLetterGrade/{finalGrade}")]
        public Task<string> ConvertToLetterGrade(double finalGrade)
        {
            return _gradeService.ConvertToLetterGrade(finalGrade);
        }

        [HttpPost]
        public void CreateGrade(Grade grade)
        {
            _gradeService.CreateGrade(grade);
        }

        [HttpDelete("{gradeid}")]
        public void DeleteGrade(int gradeid)
        {
            _gradeService.DeleteGrade(gradeid);
        }

        [HttpGet]
        [Route("GetGradeById/{gradeid}")]
        public Task<Grade> GetGradeById(int gradeid)
        {
            return _gradeService.GetGradeById(gradeid);
        }

        [HttpPost]
        [Route("GetUserGrade")]
        public Task<Grade> GetUserGrade(int userid , int assessmentid)
        {
            return _gradeService.GetUserGrade(userid, assessmentid);
        }

        [HttpPut]
        public void UpdateGrade(Grade grade)

        { 
            _gradeService.UpdateGrade(grade);
        }
    }
}

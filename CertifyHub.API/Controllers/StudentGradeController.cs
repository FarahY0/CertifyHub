using CertifyHub.Core.DTO;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradeController : ControllerBase
    {
        private readonly IStudentGradeService _studentGradeService;

        public StudentGradeController(IStudentGradeService studentGradeService)
        {
            _studentGradeService = studentGradeService;
        }

        [HttpGet("GetStudentGradeInfo")]
        public async Task<ActionResult<List<CertificateDto>>> GetStudentGradeInfo(int userId, int sectionId)
        {
            try
            {
                var result = await _studentGradeService.GetStudentGradeInfo(userId, sectionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}

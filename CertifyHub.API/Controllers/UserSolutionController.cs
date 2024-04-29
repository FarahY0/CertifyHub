using CertifyHub.Core.Data;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSolutionController : ControllerBase
    {
        private readonly IUserSolutionService _userSolutionService;
        public UserSolutionController(IUserSolutionService userSolutionService)
        {
            _userSolutionService = userSolutionService;
        }

        [HttpPost]
        public void AddUserSolution(Usersolution usersolution)
        {
            _userSolutionService.AddUserSolution(usersolution);
        }
        [HttpGet]
        public Task<Usersolution> getUserSolutionByAssessment(int assessmentId, int userId)
        {
            return _userSolutionService.getUserSolutionByAssessment(assessmentId, userId);
        }
    
    }
}

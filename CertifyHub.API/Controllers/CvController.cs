using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvService _cvService;

        public CvController(ICvService cvService)
        {
            _cvService = cvService;
        }

        [HttpDelete]
        public void DeleteCV(int id)
        {
            _cvService.DeleteCV(id);
        }

        [HttpGet]
        [Route("GetAllCVs")]
        public Task<List<Cv>> GetAllCVs()
        {
            return _cvService.GetAllCVs();
        }

        [HttpGet]
        [Route("GetCVByQrCode/{qrUrl}")]
        public Task<List<Cv>> GetCVByQrCode(string qrUrl)
        {
            return _cvService.GetCVByQrCode(qrUrl);
        }

        [HttpGet]
        [Route("GetCVDetails/{id}")]
        public Task<Cv> GetCVDetails(int id)
        {
            return _cvService.GetCVDetails(id);
        }

        [HttpGet]
        [Route("GetCVsByUser/{userId}")]
        public Task<List<Cv>> GetCVsByUser(int userId)
        {
            return _cvService.GetCVsByUser(userId);
        }

        [HttpPut]
        public void UpdateCV(Cv cv)
        {
            _cvService.UpdateCV(cv);
        }

        [HttpPost]
        public void UploadCV(Cv cv)
        {
            _cvService.UploadCV(cv);
        }
    }
}

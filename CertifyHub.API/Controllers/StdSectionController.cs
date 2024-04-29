using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdSectionController : ControllerBase
    {
        private readonly IStdSectionService _stdSectionService;

        public StdSectionController(IStdSectionService stdSectionService)
        {
            _stdSectionService = stdSectionService;
        }

        [HttpGet]
        [Route("GetAllStdSections")]
        public async Task<List<Stdsection>> GetAllStdSections()
        {
            return await _stdSectionService.GetAllStdSections();
        }

        [HttpGet]
        [Route("GetStdSectionById/{id}")]
        public async Task<Stdsection> GetStdSectionById(int id)
        {
            return await _stdSectionService.GetStdSectionById(id);
        }

        [HttpGet]
        [Route("GetStdSectionsBySectionId/{id}")]
        public async Task<List<Stdsection>> GetStdSectionsBySectionId(int id)
        {
            return await _stdSectionService.GetStdSectionsBySectionId(id);
        }

        [HttpPost]
        [Route("CreateStdSection")]
        public void CreateStdSection(Stdsection stdsection)
        {
            _stdSectionService.CreateStdSection(stdsection);
        }

        [HttpPut]
        [Route("UpdateStdSection")]
        public void UpdateStdSection(Stdsection stdsection)
        {
            _stdSectionService.UpdateStdSection(stdsection);
        }

        [HttpDelete]
        [Route("DeleteStdSection/{id}")]
        public void DeleteStdSection(int id)
        {
            _stdSectionService.DeleteStdSection(id);
        }

        [HttpGet]
        [Route("GetStdSectionsInfo")]
        public async Task<List<StdSectionInfo>> GetStdSectionsInfo()
        {
            return await _stdSectionService.GetStdSectionsInfo();
        }
        [HttpGet]
        [Route("GetNumberStudentBySectionId/{sectionId}")]
        public Task<int> GetNumberStudentBySectionId(int sectionId)
        {
            return _stdSectionService.GetNumberStudentBySectionId(sectionId);
        }
        [HttpGet]
        [Route("GetAllSectionNames")]
        public async Task<List<Section>> GetAllSectionNames()
        {
            return await _stdSectionService.GetAllSectionNames();
        }
    }
}

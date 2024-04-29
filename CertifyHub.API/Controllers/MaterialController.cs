using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }


        [HttpPost]
        public async void AddMaterial(Material material)
        {
            _materialService.AddMaterial(material);
        }


        [HttpDelete("{id}")]
        public async void DeleteMaterial(int id)
        {
            _materialService.DeleteMaterial(id);
        }




        [HttpGet]
        [Route("GetAllMaterials")]
        public async Task<List<Material>> GetAllMaterials()
        {
            return await _materialService.GetAllMaterials();
        }


        [HttpGet("GetLatestMaterials/{numMaterials}")]
        public async Task<List<Material>> GetLatestMaterials(int numMaterials)
        {
            return await _materialService.GetLatestMaterials(numMaterials);

        }


        [HttpGet]
        [Route("GetMaterialByID/{id}")]
        public async Task<Material> GetMaterialByID(int id)
        {
            return await _materialService.GetMaterialByID(id);
        }




        [HttpGet("GetMaterialsByCourse/{courseId}")]
        public async Task<List<Material>> GetMaterialsByCourse(int courseId)
        {
            return await _materialService.GetMaterialsByCourse(courseId);

        }


        [HttpPut]
        public async void UpdateMaterial(Material material)
        {
            _materialService.UpdateMaterial(material);
        }


        [HttpPost]
        [Route("uploadMatrialPath")]

        public Material UploadMatrialPath()
        {
            var file = Request.Form.Files[0];
            var fileName = $"{Guid.NewGuid().ToString() + "_" + file.FileName}";
            var fullPath = Path.Combine("C:\\Users\\DELL\\Documents\\CertifyHub\\CertifyHub\\src\\assets\\Image", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Material item = new Material();
            item.Materialpath = fileName;
            return item;
        }


        [HttpGet("GetMaterialsBySection/{sectionId}")]
        public async Task<List<Material>> GetMaterialsBySection(int sectionId)
        {
            return await _materialService.GetMaterialsBySection(sectionId);
        }


    }
}

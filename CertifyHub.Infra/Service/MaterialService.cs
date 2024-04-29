using CertifyHub.Core.Data;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
    public class MaterialService : IMaterialService
    {

        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async void AddMaterial(Material material)
        {
            _materialRepository.AddMaterial(material);
        }

        public async void DeleteMaterial(int id)
        {
            _materialRepository.DeleteMaterial(id);
        }

        public async Task<List<Material>> GetAllMaterials()
        {
            return await _materialRepository.GetAllMaterials();
        }

        public async Task<List<Material>> GetLatestMaterials(int numMaterials)
        {
            return await _materialRepository.GetLatestMaterials(numMaterials);
        }

        public async Task<Material> GetMaterialByID(int id)
        {
            return await _materialRepository.GetMaterialByID(id);
        }

        public async Task<List<Material>> GetMaterialsByCourse(int courseId)
        {
            return await _materialRepository.GetMaterialsByCourse(courseId);

        }

        public async void UpdateMaterial(Material material)
        {
            _materialRepository.UpdateMaterial(material);
        }

        public async Task<List<Material>> GetMaterialsBySection(int sectionId)
        {
            return await _materialRepository.GetMaterialsBySection(sectionId);
        }
    }
}

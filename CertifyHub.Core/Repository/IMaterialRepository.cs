using CertifyHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Repository
{
    public interface IMaterialRepository
    {
        void AddMaterial(Material material);

        void UpdateMaterial(Material material);

        void DeleteMaterial(int id);

        Task<Material> GetMaterialByID(int id);

        Task<List<Material>> GetAllMaterials();
        Task<List<Material>> GetMaterialsByCourse(int courseId);

        Task<List<Material>> GetLatestMaterials(int numMaterials);
        Task<List<Material>> GetMaterialsBySection(int SectionID);
    }
}
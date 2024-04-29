using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Service
{
    public interface IStdSectionService
    {
        Task<List<Stdsection>> GetAllStdSections();
        Task<Stdsection> GetStdSectionById(int id);
        Task<List<Stdsection>> GetStdSectionsBySectionId(int id);
        void CreateStdSection(Stdsection stdsection);
        void UpdateStdSection(Stdsection stdsection);
        void DeleteStdSection(int id);
        Task<List<StdSectionInfo>> GetStdSectionsInfo();
        Task<int> GetNumberStudentBySectionId(int sectionId);
        Task<List<Section>> GetAllSectionNames();
    }
}

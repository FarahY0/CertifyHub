using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
    public class StdSectionService : IStdSectionService
    {
        private readonly IStdSectionRepository _sectionRepository;

        public StdSectionService(IStdSectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public void CreateStdSection(Stdsection stdsection)
        {
            _sectionRepository.CreateStdSection(stdsection);
        }

        public void DeleteStdSection(int id)
        {
            _sectionRepository.DeleteStdSection(id);
        }

        public async Task<List<Stdsection>> GetAllStdSections()
        {
            return await _sectionRepository.GetAllStdSections();
        }
        public async Task<Stdsection> GetStdSectionById(int id)
        {
            return await _sectionRepository.GetStdSectionById(id);
        }

        public async Task<List<Stdsection>> GetStdSectionsBySectionId(int id)
        {
            return await _sectionRepository.GetStdSectionsBySectionId(id);
        }

        public void UpdateStdSection(Stdsection stdsection)
        {
            _sectionRepository.UpdateStdSection(stdsection);
        }
        public async Task<List<StdSectionInfo>> GetStdSectionsInfo()
        {
           return await _sectionRepository.GetStdSectionsInfo();
        }
        public Task<int> GetNumberStudentBySectionId(int sectionId)
        {
            return _sectionRepository.GetNumberStudentBySectionId(sectionId);

        }
        public async Task<List<Section>> GetAllSectionNames()
        {
            return await _sectionRepository.GetAllSectionNames();
        }
       


    }
}

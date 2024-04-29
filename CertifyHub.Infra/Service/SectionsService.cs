using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;




namespace CertifyHub.Infra.Service
{
	public class SectionsService : ISectionsService
	{
		private readonly ISectionsRepository sectionRepository;

		public SectionsService(ISectionsRepository sectionRepository)
		{
			this.sectionRepository = sectionRepository;
		}
		public List<GetAllsections> GetAllSections()
		{
			return sectionRepository.GetAllSections();
		}
		public void CreateSection(Section section)
		{
			sectionRepository.CreateSection(section);
		}
		public void UpdateSection(Section section)
		{
			sectionRepository.UpdateSection(section);
		}
		public void DeleteSection(int SectionId)
		{
			sectionRepository.DeleteSection(SectionId);
		}
		public Section GetSectionById(int SectionId)
		{
			return sectionRepository.GetSectionById(SectionId);
		}
        public Task<List<Section>> GetSectionByINSTRUCTORID(int InstructorId)
        {
            return sectionRepository.GetSectionByINSTRUCTORID(InstructorId);
        }

    }
}

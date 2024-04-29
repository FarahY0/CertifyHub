using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;

namespace CertifyHub.Core.Service
{
	public interface ISectionsService
	{
		public List<GetAllsections> GetAllSections();
		public void CreateSection(Section section);
		public void DeleteSection(int SectionId);
		public void UpdateSection(Section section);
		Section GetSectionById(int SectionId);
        Task<List<Section>> GetSectionByINSTRUCTORID(int InstructorId);
    }
}

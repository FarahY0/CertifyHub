using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Repository
{
	public interface ISectionsRepository
	{
		public List<GetAllsections> GetAllSections();
	
		public void CreateSection(Section section);
		public void UpdateSection(Section section);
		
		public void DeleteSection(int SectionId);
		
		Section GetSectionById(int SectionId);
        Task<List<Section>> GetSectionByINSTRUCTORID(int InstructorId);


    }
}

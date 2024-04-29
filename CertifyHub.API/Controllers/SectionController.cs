using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SectionController : ControllerBase
	{
		private readonly ISectionsService sectionService;
		public SectionController(ISectionsService sectionService)
		{
			this.sectionService = sectionService;
		}

		[HttpGet]
		[Route("GetAllSections")]
		public List<GetAllsections> GetAllSections()
		{
			return sectionService.GetAllSections();
		}

		[HttpPost]
		[Route("CreateSection")]
		public void CreateSection(Section section)
		{
			sectionService.CreateSection(section);
		}

		[HttpPut]
		[Route("UpdateSection")]
		public void UpdateSection(Section section)
		{
			sectionService.UpdateSection(section);
		}

		[HttpDelete]
		[Route("DeleteSection/{SectionId}")]
		public void DeleteSection(int SectionId)
		{
			sectionService.DeleteSection(SectionId);
		}

		[HttpGet]
		[Route("GetSectionById/{SectionId}")]
		[CheckClaims("RoleId","2")]
		public Section GetSectionById(int SectionId)
		{
			return sectionService.GetSectionById(SectionId);
		}

		[Route("UploadSectionImage")]
		[HttpPost]
		[CheckClaims("RoleId","2")]
		public Section UploadSectionIMage()
		{
			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			var fullPath = Path.Combine("Images", fileName);
			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			Section item = new Section();
			item.Imagepath = fileName;
			return item;
		}
        [HttpGet]
        [Route("GetSectionByINSTRUCTORID/{InstructorId}")]
		[CheckClaims("RoleId","2")]
        public Task<List<Section>> GetSectionByINSTRUCTORID(int InstructorId)
        {
            return sectionService.GetSectionByINSTRUCTORID(InstructorId);
        }
    }
}

using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using CertifyHub.Infra.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CourseController : ControllerBase
	{
		private readonly ICourseService courseService;
		public CourseController(ICourseService courseService)
		{
			this.courseService = courseService;
		}

		[HttpGet]
		[Route("GetAllCourses")]
       
        public List<Course> GetAllCourses()
		{
			return courseService.GetAllCourses();
		}

		[HttpGet]
		[Route("GetNumberOfCourses")]
		public List<ProgramsInformation> GetNumberOfCourses()
		{
			return courseService.GetNumberOfCourses();
		}
		[HttpPost]
		[Route("CreateCourse")]
		public void CreateCourse(Course course)
		{
			courseService.CreateCourse(course);
		}

		[HttpPut]
		[Route("UpdateCourse")]
		public void UpdateCourse(Course course)
		{
			courseService.UpdateCourse(course);
		}

		[HttpDelete]
		[Route("DeleteCourse/{CourseId}")]
		public void DeleteCourse(int CourseId)
		{
			courseService.DeleteCourse(CourseId);
		}

		[HttpGet]
		[Route("GetCourseById/{CourseId}")]
        
        public CourseDetails GetCourseById(int CourseId)
		{
			return courseService.GetCourseById(CourseId);
		}

		[Route("uploadCourseImage")]
		[HttpPost]
		public Course UploadCourseIMage()
		{
			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			var fullPath = Path.Combine("C:\\Users\\DELL\\Documents\\CertifyHub\\CertifyHub\\src\\assets\\Image", fileName);
			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			Course item = new Course();
			item.Imagepath = fileName;
			return item;
		}
        [HttpGet]
        [Route("GetCoursesByUserId/{userId}")]
        [CheckClaims("RoleId", "3")]
        public List<GetCourses> GetCoursesByUserId(int userId)
        {
            return courseService.GetCoursesByUserId(userId);
        }

    }
}

using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Service
{
	public interface ICourseService
	{
		public List<Course> GetAllCourses();
		public List<ProgramsInformation> GetNumberOfCourses();
		public void CreateCourse(Course course);
		public void DeleteCourse(int CourseId);
		public void UpdateCourse(Course course);
        CourseDetails GetCourseById(int CourseId);
        List<GetCourses> GetCoursesByUserId(int userId);
    }
}

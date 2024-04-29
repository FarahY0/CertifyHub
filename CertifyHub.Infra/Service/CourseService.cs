using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Service
{
	public class CourseService : ICourseService
	{
		private readonly ICourseRepository courseRepository;

		public CourseService(ICourseRepository courseRepository)
		{
			this.courseRepository = courseRepository;
		}
		public List<Course> GetAllCourses()
		{
			return courseRepository.GetAllCourses();
		}
		public void CreateCourse(Course course)
		{
			courseRepository.CreateCourse(course);
		}
		public void UpdateCourse(Course course)
		{
			courseRepository.UpdateCourse(course);
		}
		public void DeleteCourse(int CourseId)
		{
			courseRepository.DeleteCourse(CourseId);
		}
		public CourseDetails GetCourseById(int CourseId)
		{
			return courseRepository.GetCourseById(CourseId);
		}

		public List<ProgramsInformation> GetNumberOfCourses()
		{
			return courseRepository.GetNumberOfCourses();
		}

        public List<GetCourses> GetCoursesByUserId(int userId)
        {
            return courseRepository.GetCoursesByUserId(userId);
        }

        //public List<Course> getCoursesByUserId(int userId)
        //{
        //    return courseRepository.getCoursesByUserId(userId);
        //}
    }
}

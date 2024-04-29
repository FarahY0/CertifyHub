using CertifyHub.Core.Common;
using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Infra.Repository
{
	public class CourseRepository:ICourseRepository
	{
		private readonly IDbContext dbContext;
		public CourseRepository(IDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = dbContext.Connection.Query<Course, Program, Course>("Course_Package.GetAllCourses",
                (course, program) => {
                    course.Program = program;
                    return course;
                },
                splitOn: "ProgramId"
                , commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ProgramsInformation> GetNumberOfCourses()
		{
			var result =
		   dbContext.Connection.Query<ProgramsInformation>("Course_Package.GetNumberOfCourses", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}
		public void CreateCourse(Course course)
		{
			var c = new DynamicParameters();
			c.Add("Course_Name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("Program_Id", course.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			c.Add("Start_Date", course.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			c.Add("End_Date", course.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			c.Add("Image_Path", course.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("NumberSections", course.Numberofsections, dbType: DbType.Int32, direction: ParameterDirection.Input);
			c.Add("CPrerequisite", course.Prerequisite, dbType: DbType.String, direction: ParameterDirection.Input);
			var result = dbContext.Connection.Execute("Course_Package.CREATECOURSE", c, commandType: CommandType.StoredProcedure);

		}
		public void UpdateCourse(Course course)
		{
			var u = new DynamicParameters();
			u.Add("Course_Id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("Course_Name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("Program_Id", course.Programid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("Start_Date", course.Startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			u.Add("End_Date", course.Enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
			u.Add("Image_Path", course.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("NumberSections", course.Numberofsections, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("CPrerequisite", course.Prerequisite, dbType: DbType.String, direction: ParameterDirection.Input);
			var result = dbContext.Connection.Execute("Course_Package.UPDATECOURSE", u, commandType: CommandType.StoredProcedure);
		}

		public void DeleteCourse(int CourseId)
		{
			var d = new DynamicParameters();
			d.Add("Course_Id", CourseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = dbContext.Connection.Execute("Course_Package.DeleteCourse", d, commandType: CommandType.StoredProcedure);
		}
		public CourseDetails GetCourseById(int CourseId)
		{
			var g = new DynamicParameters();
			g.Add("Course_Id", CourseId, dbType: DbType.Int32,direction: ParameterDirection.Input);
			IEnumerable<CourseDetails> result = dbContext.Connection.Query<CourseDetails>("Course_Package.GetCourseById", g, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

        public List<GetCourses> GetCoursesByUserId(int userId)
        {
            var g = new DynamicParameters();
			g.Add("student_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<GetCourses> result = dbContext.Connection.Query<GetCourses>("Course_Package.GetCoursesByUserId", g, commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

        //public List<GetCourses> GetCoursesByUserId(int userId)
        //{
        //    var g = new DynamicParameters();
        //    g.Add("Course_Id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    IEnumerable<GetCourses> result = dbContext.Connection.Query<GetCourses>("Course_Package.GetCoursesByUserId", g, commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}


        //public List<Course> getCoursesByUserId(int userId)
        //{
        //	var g = new DynamicParameters();
        //	g.Add("student_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //	IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetCoursesByUserId", g, commandType: CommandType.StoredProcedure);
        //	return result.ToList();
        //}

        //List<GetCourses> ICourseRepository.getCoursesByUserId(int userId)
        //{
        //    var g = new DynamicParameters();
        //    g.Add("student_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    IEnumerable<Course> result = dbContext.Connection.Query<Course>("Course_Package.GetCoursesByUserId", g, commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}

        //public async List<Task<GetCourses>> GetCoursesByUserId(int userId)
        //      {
        //          var g = new DynamicParameters();
        //          g.Add("student_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //          var result = await dbContext.Connection.QueryAsync<GetCourses>("Course_Package.GetCoursesByUserId", g, commandType: CommandType.StoredProcedure);
        //          return result.ToList();
        //      }
    }

}



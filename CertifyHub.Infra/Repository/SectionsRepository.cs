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
	public class SectionsRepository : ISectionsRepository
	{
		private readonly IDbContext dbContext;
		public SectionsRepository(IDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public List<GetAllsections> GetAllSections()
		{
			IEnumerable<GetAllsections> result = dbContext.Connection.Query<GetAllsections>("Section_Package.GetAllSections", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public Section GetSectionById(int SectionId)
		{
			var g = new DynamicParameters();
			g.Add("Section_Id", SectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			IEnumerable<Section> result = dbContext.Connection.Query<Section>("Section_Package.GetSectionById", g, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void DeleteSection(int SectionId)
		{
			var d = new DynamicParameters();
			d.Add("Section_Id", SectionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
			var result = dbContext.Connection.Execute("Section_Package.DeleteSection", d, commandType: CommandType.StoredProcedure);
		}
		public async void CreateSection(Section section)
		{
			var c = new DynamicParameters();
			c.Add("Section_Name", section.Sectionname, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("Time_Lecture", section.Timelecture, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("Meeting_Link", section.Meetinglink, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("Course_Id", section.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			c.Add("Instructor_Id", section.Instructorid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			c.Add("Lecture_Days", section.Lecturedays, dbType: DbType.String, direction: ParameterDirection.Input);
			c.Add("Image_Path", section.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			await dbContext.Connection.ExecuteAsync("Section_Package.CreateSection", c, commandType: CommandType.StoredProcedure);
		

		}
		public void UpdateSection(Section section)
		{
			var u = new DynamicParameters();
			u.Add("Section_Id", section.Sectionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("Section_Name", section.Sectionname, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("Time_Lecture", section.Timelecture, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("Meeting_Link", section.Meetinglink, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("Course_Id", section.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("Instructor_Id", section.Instructorid, dbType: DbType.Int32, direction: ParameterDirection.Input);
			u.Add("Lecture_Days", section.Lecturedays, dbType: DbType.String, direction: ParameterDirection.Input);
			u.Add("Image_Path", section.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
			var result = dbContext.Connection.Execute("Section_Package.UpdateSection", u, commandType: CommandType.StoredProcedure);
		}

      
        public async Task<List<Section>> GetSectionByINSTRUCTORID(int InstructorId)
        {
            var f = new DynamicParameters();
            f.Add("S_InstructorId", InstructorId, DbType.Int32, ParameterDirection.Input);
            IEnumerable<Section> result = dbContext.Connection.Query<Section>("Section_Package.GetSectionByINSTRUCTORID", f, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}

using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.Repository
{
    public  interface IAttendanceRepository
    {
        void  InsertAttendance(Attendance attendance);
        void  UpdateAttendance(Attendance attendance);
        void DeleteAttendance(int id);
        Task<Attendance> GetAttendanceDetails(int id);
        Task<List<Attendance>> GetAttendanceBySection(int sectionId);
        Task<List<Attendance>> GetAttendanceByUser(int userId);
        Task<List<Attendance>> GetAttendanceByDate(DateTime date);
        Task<List<Attendance>> GetAttendanceByStatus(string attendanceStatus);
        //List<GetAllAttendaceDto> GetAllUsersWithSections();
        public List<GetAllAttendaceDto> GetAllUsersWithSections();
        Task<int> GetPresentAttendanceCount();
        Task<int> GetAbsentAttendanceCount();
        Task<List<GetUserInSection>> GetStudentsInSectionAsync(int sectionId , int studentId);
        void UpdateStatus(int studentId ,int sectionId , string newStatus);
        void InsertAttendanceData(Attendance attendance);
    }
}

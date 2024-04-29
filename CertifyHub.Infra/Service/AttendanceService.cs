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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {

            _attendanceRepository= attendanceRepository;
        }

        public void DeleteAttendance(int id)
        {
            _attendanceRepository.DeleteAttendance(id);
        }
       

        public Task<List<Attendance>> GetAttendanceByDate(DateTime date)
        {
            return _attendanceRepository.GetAttendanceByDate(date);
        }

        public Task<List<Attendance>> GetAttendanceBySection(int sectionId)
        {
            return _attendanceRepository.GetAttendanceBySection(sectionId);
        }

        public Task<List<Attendance>> GetAttendanceByStatus(string attendanceStatus)
        {
            return _attendanceRepository.GetAttendanceByStatus(attendanceStatus);
        }
        
        public Task<List<Attendance>> GetAttendanceByUser(int userId)
        {
            return _attendanceRepository.GetAttendanceByUser(userId);
        }

        public Task<Attendance> GetAttendanceDetails(int id)
        {
            return _attendanceRepository.GetAttendanceDetails(id);
        }

        public Task<int> GetPresentAttendanceCount()
        {
            return _attendanceRepository.GetPresentAttendanceCount();
        }

        public Task<int> GetAbsentAttendanceCount()
        {
            return _attendanceRepository.GetAbsentAttendanceCount();
        }

        public void InsertAttendance(Attendance attendance)
        {
            _attendanceRepository.InsertAttendance(attendance);
        }

        public void UpdateAttendance(Attendance attendance)
        {
            _attendanceRepository.UpdateAttendance  (attendance);
        }

        public List<GetAllAttendaceDto> GetAllUsersWithSections()
        {
            return _attendanceRepository.GetAllUsersWithSections();
        }

        public Task<List<GetUserInSection>> GetStudentsInSectionAsync(int sectionId, int studentId)
        {
            return _attendanceRepository.GetStudentsInSectionAsync(sectionId, studentId);
        }

      

        public void InsertAttendanceData(Attendance attendance)
        {
            _attendanceRepository.InsertAttendanceData(attendance);
        }

        public void UpdateStatus(int studentId, int sectionId, string newStatus)
        {
            _attendanceRepository.UpdateStatus(studentId, sectionId, newStatus);
        }
    }
}

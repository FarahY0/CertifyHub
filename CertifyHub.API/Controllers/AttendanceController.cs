using CertifyHub.Core.Data;
using CertifyHub.Core.DTO;
using CertifyHub.Core.Repository;
using CertifyHub.Core.Service;
using CertifyHub.Infra.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {

            _attendanceService = attendanceService;
        }


        [HttpPost]
        public async void InsertAttendance(Attendance attendance)
        {
            _attendanceService.InsertAttendance(attendance);
        }

        [HttpPut]
        public async void UpdateAttendance(Attendance attendance)
        {
            _attendanceService.UpdateAttendance(attendance);
        }

        [HttpDelete("{id}")] 
        public async void DeleteAttendance(int id)
        {
            _attendanceService.DeleteAttendance(id);
        }



        [HttpGet]
        [Route("GetAttendanceByDate/{date}")]
        public async Task<List<Attendance>> GetAttendanceByDate(DateTime date)
        {
            return await _attendanceService.GetAttendanceByDate(date);
        }


        [HttpGet]
        [Route("GetAttendanceBySection/{sectionId}")]
        public async Task<List<Attendance>> GetAttendanceBySection(int sectionId)
        {
            return await _attendanceService.GetAttendanceBySection(sectionId);
        }

        [HttpGet]
        [Route("GetAttendanceByStatus/{attendanceStatus}")]

        public async Task<List<Attendance>> GetAttendanceByStatus(string attendanceStatus)
        {
            return await  _attendanceService.GetAttendanceByStatus(attendanceStatus);
        }


        [HttpGet]
        [Route("GetAttendanceByUser/{userId}")]
        public async Task<List<Attendance>> GetAttendanceByUser(int userId)
        {
            return await _attendanceService.GetAttendanceByUser(userId);
        }

        [HttpGet]
        [Route("GetAttendanceDetails/{id}")]
        public async Task<Attendance> GetAttendanceDetails(int id)
        {
            return await _attendanceService.GetAttendanceDetails(id);
        }

        [HttpGet]
        [Route("GetPresentAttendanceCount")]
        public async Task<int> GetPresentAttendanceCount()
        {
            return await _attendanceService.GetPresentAttendanceCount();
        }

        [HttpGet]
        [Route("GetAbsentAttendanceCount")]
        public async Task<int> GetAbsentAttendanceCount()
        {
            return await  _attendanceService.GetAbsentAttendanceCount();
        }
        [HttpGet]
        [Route("GetAllUsersWithSections")]
        public List<GetAllAttendaceDto> GetAllUsersWithSections()
        {
            return _attendanceService.GetAllUsersWithSections();
        }
        [HttpGet]
        [Route("GetStudentsInSectionAsync/{sectionId}")]
       
        public Task<List<GetUserInSection>> GetStudentsInSectionAsync(int sectionId, int studentId)
        {
            return _attendanceService.GetStudentsInSectionAsync(sectionId ,studentId);
        }
       [HttpPost]
        [Route("InsertAttendanceData")]

        public void InsertAttendanceData(Attendance attendance)
        {
            _attendanceService.InsertAttendanceData(attendance);
        }
        [HttpPost]
        [Route("UpdateStatus")]
        public void UpdateStatus(int studentId, int sectionId, string newStatus)
        {
            _attendanceService.UpdateStatus(studentId, sectionId, newStatus);
        }

    }
}

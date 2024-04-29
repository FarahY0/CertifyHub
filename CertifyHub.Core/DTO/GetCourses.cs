using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class GetCourses
    {
        public decimal Courseid { get; set; }
        public string? Coursename { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string? Imagepath { get; set; }
        public string? Trackname { get; set; }
        public string? Meetinglink { get; set; }
        public string? Timelecture { get; set; }
    }
}

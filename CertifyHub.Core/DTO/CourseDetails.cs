using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class CourseDetails
    {
        public string? Coursename { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string? Imagepath { get; set; }

        public decimal? Numberofsections { get; set; }

        public decimal? Numberofbatches { get; set; }
        public decimal? Studentgrade { get; set; }

        public string? Materialname { get; set; }
        public string? Materialpath { get; set; }

        public string? Trackname { get; set; }
        public string? Programperiod { get; set; }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public string? Sectionname { get; set; }
        public string? Timelecture { get; set; }
        public string? Meetinglink { get; set; }
        public string? Lecturedays { get; set; }

    }
}

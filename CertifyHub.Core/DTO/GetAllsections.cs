using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class GetAllsections
    {
        public string SectionID { get; set; }

        public string SectionName { get; set; }
        public string TimeLecture { get; set; }
        public string MeetingLink { get; set; }
        public string CourseName { get; set; }

        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public string LectureDays { get; set; }
        public string ImagePath { get; set; }
    }
}

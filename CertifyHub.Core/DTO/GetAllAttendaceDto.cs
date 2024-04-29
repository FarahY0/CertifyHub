using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class GetAllAttendaceDto
    {
        
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Sectionname { get; set; }
        public DateTime? Dateofattendance { get; set; }
        public string? Status { get; set; }

    }
}

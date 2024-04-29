using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class GetUserInSection
    {
        public string? Status { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Dateofattendance { get; set; }
    }
}

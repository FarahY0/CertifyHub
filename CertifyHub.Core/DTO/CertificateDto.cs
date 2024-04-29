using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class CertificateDto
    {
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string CourseName { get; set; }
        public int TOTAL_GRADE_SUM { get; set; }
        public string QRCODEURL { get; set; }
    }
}

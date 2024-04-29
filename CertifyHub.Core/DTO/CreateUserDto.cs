using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertifyHub.Core.DTO
{
    public class CreateUserDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Imagepath { get; set; }
        public string? Address { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime? Registrationdate { get; set; }
        public bool? Isactive { get; set; }
        public decimal Roleid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        }
}

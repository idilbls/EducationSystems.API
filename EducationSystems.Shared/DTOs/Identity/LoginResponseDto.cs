using EducationSystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs.Identity
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
        public string AccessToken { get; set; }
        public UserType UserType { get; set; }
    }
}

using EducationSystems.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Models.Entities.IdentityAuth
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public UserType Type { get; set; }
        public string? LocalAddress { get; set; }
    }
}

using EducationSystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs
{
    public class StudentAttendanceResponse
    {
        public string Number { get; set; }
        public string FullName { get; set; }
        public StatusType StatusType { get; set; }
    }
}

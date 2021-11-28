using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs
{
    public class StudentAttendanceListResponse
    {
        public List<StudentAttendanceResponse> StudentAttendances { get; set; }
    }
}

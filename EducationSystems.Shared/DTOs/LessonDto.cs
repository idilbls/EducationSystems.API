using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int? ProfessorId { get; set; }
        public bool IsActive { get; set; }
    }
}

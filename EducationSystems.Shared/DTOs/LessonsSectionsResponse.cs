using EducationSystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Shared.DTOs
{
    public class LessonsSectionsResponse
    {
        public int? LessonId { get; set; }
        public int? ProfessorId { get; set; }
        public int UserLessonMapId { get; set; }
        public int? UserId { get; set; }
        public string LessonTitle { get; set; }
        public string LessonCode { get; set; }
        public DateTime LessonDate { get; set; }
        public StatusType StatusType { get; set; }
    }
}

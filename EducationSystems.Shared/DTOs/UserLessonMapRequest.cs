using EducationSystems.Models.Enums;

namespace EducationSystems.Shared.DTOs
{
    public class UserLessonMapRequest
    {
        public int UserLessonMapId { get; set; }
        public StatusType StatusType { get; set; }
    }
}

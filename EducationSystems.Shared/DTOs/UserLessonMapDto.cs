using EducationSystems.Models.Enums;

namespace EducationSystems.Shared.DTOs
{
    public class UserLessonMapDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int LessonId { get; set; }

        public StatusType StatusType { get; set; }
    }
}

using EducationSystems.Models.Entities.Core;
using EducationSystems.Models.Entities.IdentityAuth;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationSystems.Models.Entities.Map
{
    public class UserLessonMap : BaseEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? LessonId { get; set; }

        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }

        public StatusType StatusType { get; set; }
    }
}

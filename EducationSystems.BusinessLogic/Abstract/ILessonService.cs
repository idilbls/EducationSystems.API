using EducationSystems.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.BusinessLogic.Abstract
{
    public interface ILessonService
    {
        Task<IList<LessonDto>> GetStudentLessons(int userId);
        Task<IList<LessonDto>> GetProffesorLessons(int userId);
        Task<IList<LessonDto>> GetLessonsSections(SectionRequestDto sectionRequest);
        Task<bool> UpdateStudentAttendance(UserLessonMapRequest request);
        Task<IList<LessonDto>> GetProffesorLessonsSections(SectionRequestDto sectionRequest);
        Task<IList<UserLessonMapDto>> GetLessonsAttendance(int lessonId);
    }
}

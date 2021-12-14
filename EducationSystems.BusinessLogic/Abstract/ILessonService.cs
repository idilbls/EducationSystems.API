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
        Task<LessonListResponse> GetStudentLessons(int userId);
        Task<LessonListResponse> GetProffesorLessons(int userId);
        Task<LessonSectionsListResponse> GetLessonsSections(SectionRequestDto sectionRequest);
        Task<bool> UpdateStudentAttendance(UserLessonMapRequest request);
        Task<LessonListResponse> GetProffesorLessonsSections(SectionRequestDto sectionRequest);
        Task<StudentAttendanceListResponse> GetLessonsAttendance(int lessonId);
        Task<bool> FinishLesson(int lessonId);
        Task<bool> StartLesson(int lessonId);
        Task<LessonDto> GetLessonById(int lessonId);
    }
}

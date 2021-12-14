using EducationSystems.BusinessLogic.Abstract;
using EducationSystems.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost("get_student_lessons")]
        public async Task<LessonListResponse> GetStudentLessons([FromBody] int userId)
        {
            return await _lessonService.GetStudentLessons(userId);
        }

        [HttpPost("get_proffesor_lessons")]
        public async Task<LessonListResponse> GetProffesorLessons([FromBody] int userId)
        {
            return await _lessonService.GetProffesorLessons(userId);
        }

        [HttpPost("get_lessons_sections")]
        public async Task<LessonSectionsListResponse> GetLessonsSections([FromBody] SectionRequestDto sectionRequest)
        {
            return await _lessonService.GetLessonsSections(sectionRequest);
        }

        [HttpPost("get_proffesor_lesson_sections")]
        public async Task<LessonListResponse> GetProffesorLessonsSections([FromBody] SectionRequestDto sectionRequest)
        {
            return await _lessonService.GetProffesorLessonsSections(sectionRequest);
        }

        [HttpPost("update_attendance")]
        public async Task<bool> UpdateStudentAttendance([FromBody] UserLessonMapRequest request)
        {
            return await _lessonService.UpdateStudentAttendance(request);
        }

        [HttpPost("get_lessons_attendance")]
        public async Task<StudentAttendanceListResponse> GetLessonsAttendance([FromBody] int lessonId)
        {
            return await _lessonService.GetLessonsAttendance(lessonId);
        }

        [HttpPost("finish_lesson")]
        public async Task<bool> FinishLesson([FromBody] int lessonId)
        {
            return await _lessonService.FinishLesson(lessonId);
        }

        [HttpPost("start_lesson")]
        public async Task<bool> StartLesson([FromBody] int lessonId)
        {
            return await _lessonService.StartLesson(lessonId);
        }

        [HttpPost("get_lesson_by_id")]
        public async Task<LessonDto> GetLessonById([FromBody] int lessonId)
        {
            return await _lessonService.GetLessonById(lessonId);
        }
    }
}

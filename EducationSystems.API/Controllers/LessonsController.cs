﻿using EducationSystems.BusinessLogic.Abstract;
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
        public async Task<IList<LessonDto>> GetStudentLessons([FromBody] int userId)
        {
            return await _lessonService.GetStudentLessons(userId);
        }

        [HttpPost("get_proffesor_lessons")]
        public async Task<IList<LessonDto>> GetProffesorLessons([FromBody] int userId)
        {
            return await _lessonService.GetProffesorLessons(userId);
        }

        [HttpPost("get_lessons_sections")]
        public async Task<IList<UserLessonMapDto>> GetLessonsSections(SectionRequestDto sectionRequest)
        {
            return await _lessonService.GetLessonsSections(sectionRequest);
        }

        [HttpPost("get_proffesor_lesson_sections")]
        public async Task<IList<LessonDto>> GetProffesorLessonsSections(SectionRequestDto sectionRequest)
        {
            return await _lessonService.GetProffesorLessonsSections(sectionRequest);
        }
    }
}

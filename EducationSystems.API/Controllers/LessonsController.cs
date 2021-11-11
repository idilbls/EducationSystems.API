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

        [HttpPost("getStudentLessons")]
        public async Task<IList<LessonDto>> GetStudentLessons([FromBody] int userId)
        {
            return await _lessonService.GetStudentLessons(userId);
        }
    }
}

using AutoMapper;
using EducationSystems.BusinessLogic.Abstract;
using EducationSystems.Core.Context;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.BusinessLogic.Service
{
    public class LessonService : ILessonService
    {
        private readonly EducationSystemsDbContext _context;
        private readonly IMapper _mapper;

        public LessonService(EducationSystemsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IList<UserLessonMapDto>> GetLessonsAttendance(int lessonId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLessonMapDto>> GetLessonsSections(SectionRequestDto sectionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IList<LessonDto>> GetProffesorLessons(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<LessonDto>> GetProffesorLessonsSections(SectionRequestDto sectionRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<LessonDto>> GetStudentLessons(int userId)
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();

                var studentLessons = _context.UserLessonMaps.Where(u => u.UserId == userId).ToList();
                foreach (var item in studentLessons)
                {
                    var value = await _context.Lessons.FindAsync(item.LessonId);
                    lessons.Add(value);
                }
                var userLesson = lessons.Distinct().ToList();
                var mappedLessons = _mapper.Map<IList<Lesson>, List<LessonDto>>(userLesson);
                return mappedLessons;

                //Code a göre tekilleştirmemiz gerekiyor. Yoksa tüm dersleri getiriyor.
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> UpdateStudentAttendance(UserLessonMapRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using EducationSystems.BusinessLogic.Abstract;
using EducationSystems.Core.Context;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Map;
using EducationSystems.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<LessonDto>> GetLessonsSections(SectionRequestDto sectionRequest)
        {
            List<Lesson> lessons = new List<Lesson>();
            var lessonSections = _context.UserLessonMaps
                .Where(s => s.UserId == sectionRequest.userId && s.Lesson.Code == sectionRequest.LessonCode).ToList();

            foreach (var lesson in lessonSections)
            {
                var value = await _context.Lessons.FindAsync(lesson.LessonId);
                lessons.Add(value);
            }

            var mappedLessons = _mapper.Map<List<Lesson>, IList<LessonDto>>(lessons);
            return mappedLessons;
        }

        public async Task<IList<LessonDto>> GetProffesorLessons(int userId)
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();

                var proffesorLessons = _context.Lessons.Where(u => u.ProfessorId == userId).ToList();
                
                var groupedLessonList = proffesorLessons.GroupBy(u => u.Code).Select(grp => grp.First()).ToList();
                var mappedLessons = _mapper.Map<List<Lesson>, IList<LessonDto>>(groupedLessonList);
                return mappedLessons;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IList<LessonDto>> GetProffesorLessonsSections(SectionRequestDto sectionRequest)
        {
 
            var lessonSections = _context.Lessons
                .Where(s => s.ProfessorId == sectionRequest.userId && s.Code == sectionRequest.LessonCode).ToList();

            var mappedLessons = _mapper.Map<List<Lesson>, IList<LessonDto>>(lessonSections);
            return mappedLessons;
        }

        public async Task<IList<UserLessonMapDto>> GetStudentLessons(int userId)
        {
            try
            {
                var studentLessons = _context.UserLessonMaps.Where(u => u.UserId == userId).ToList();
               
                var groupedLessonList = studentLessons.GroupBy(u => u.Lesson.Code).Select(grp => grp.First()).ToList();
                var mappedLessons = _mapper.Map<List<UserLessonMap>,IList<UserLessonMapDto>>(groupedLessonList);
                return mappedLessons;
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

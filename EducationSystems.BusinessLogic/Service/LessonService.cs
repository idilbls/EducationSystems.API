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

        public async Task<StudentAttendanceListResponse> GetLessonsAttendance(int lessonId)
        {
            List<StudentAttendanceResponse> studentAttendanceResponse = new List<StudentAttendanceResponse>();

            var studentAttendances = _context.UserLessonMaps.Where(x => x.LessonId == lessonId).ToList();
            foreach (var item in studentAttendances)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == item.UserId);
                studentAttendanceResponse.Add(new StudentAttendanceResponse 
                {
                    Number = user.Number,
                    FullName = user.Name +" "+ user.Surname,
                    StatusType = item.StatusType
                });
            }
            var attendanceList = new StudentAttendanceListResponse() { StudentAttendances = studentAttendanceResponse };
            return attendanceList;
        }

        public async Task<LessonSectionsListResponse> GetLessonsSections(SectionRequestDto sectionRequest)
        {
            List<LessonsSectionsResponse> lessonsSectionsResponses = new List<LessonsSectionsResponse>();
            var lessonSections = _context.UserLessonMaps
                .Where(s => s.UserId == sectionRequest.userId && s.Lesson.Code == sectionRequest.LessonCode).ToList();

            foreach (var item in lessonSections)
            {
                var lessonInfo = _context.Lessons.Where(c => c.Id == item.LessonId).FirstOrDefault();

                if(lessonInfo != null) 
                {
                    lessonsSectionsResponses.Add(new LessonsSectionsResponse
                    {
                        UserId = item.UserId,
                        LessonCode = lessonInfo.Code,
                        LessonTitle = lessonInfo.Title,
                        LessonDate = lessonInfo.Date,
                        StatusType = item.StatusType,
                        UserLessonMapId = item.Id,
                        LessonId = item.LessonId,
                        ProfessorId = lessonInfo.ProfessorId                      

                    });
                }

            }
            var lessonList = new LessonSectionsListResponse() { Lessons = lessonsSectionsResponses };
            return lessonList;
        }

        public async Task<LessonListResponse> GetProffesorLessons(int userId)
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();

                var proffesorLessons = _context.Lessons.Where(u => u.ProfessorId == userId).ToList();
                
                var groupedLessonList = proffesorLessons.GroupBy(u => u.Code).Select(grp => grp.First()).ToList();
                var mappedLessons = _mapper.Map<List<Lesson>, List<LessonDto>>(groupedLessonList);

                var lessonList = new LessonListResponse() { Lessons = mappedLessons };
                return lessonList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LessonListResponse> GetProffesorLessonsSections(SectionRequestDto sectionRequest)
        {
 
            var lessonSections = _context.Lessons
                .Where(s => s.ProfessorId == sectionRequest.userId && s.Code == sectionRequest.LessonCode).ToList();

            var mappedLessons = _mapper.Map<List<Lesson>, List<LessonDto>>(lessonSections);

            var lessonList = new LessonListResponse() { Lessons = mappedLessons };
            return lessonList;
        }

        public async Task<LessonListResponse> GetStudentLessons(int userId)
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();
                var studentLessons = _context.UserLessonMaps.Where(u => u.UserId == userId).ToList();

                foreach (var lesson in studentLessons)
                {
                    var value = await _context.Lessons.FindAsync(lesson.LessonId);
                    lessons.Add(value);
                }
               

                var groupedLessonList = lessons.GroupBy(u => u.Code).Select(grp => grp.First()).ToList();
                var mappedLessons = _mapper.Map<List<Lesson>,List<LessonDto>>(groupedLessonList);

                var lessonList = new LessonListResponse() { Lessons= mappedLessons};
                return lessonList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateStudentAttendance(UserLessonMapRequest request)
        {
            try
            {
                var studentAttendance = _context.UserLessonMaps.FirstOrDefault(x => x.Id == request.UserLessonMapId);

                var lesson = _context.Lessons.FirstOrDefault(x => x.Id == studentAttendance.LessonId);
                if (lesson.IsActive == true)
                {
                    studentAttendance.StatusType = request.StatusType;

                    _context.UserLessonMaps.Update(studentAttendance);

                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> FinishLesson(int lessonId)
        {
            try
            {
                var studentAttendanceList = _context.UserLessonMaps.Where(x => x.LessonId == lessonId).ToList();
                if(studentAttendanceList != null) { 
                    foreach (var studentAttendance in studentAttendanceList)
                    {
                        if(studentAttendance.StatusType == Models.Enums.StatusType.Attendance)
                        {
                            studentAttendance.StatusType = Models.Enums.StatusType.Absent;
                            _context.UserLessonMaps.Update(studentAttendance);
                            await _context.SaveChangesAsync();
                        }
                    }
                    var lesson = _context.Lessons.FirstOrDefault(x => x.Id == lessonId);
                    lesson.IsActive = false;
                    _context.Lessons.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> StartLesson(int lessonId)
        {
            try
            {
                var lesson = _context.Lessons.FirstOrDefault(x => x.Id == lessonId);

                lesson.IsActive = true;

                _context.Lessons.Update(lesson);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<LessonDto> GetLessonById(int lessonId)
        {
            try
            {
                var lesson = _context.Lessons.FirstOrDefault(x => x.Id == lessonId);
                var mappedLessons = _mapper.Map<Lesson, LessonDto>(lesson);
                return mappedLessons;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

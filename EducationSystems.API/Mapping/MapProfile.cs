using AutoMapper;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Map;
using EducationSystems.Shared.DTOs;

namespace EducationSystems.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<UserLessonMap, UserLessonMapDto>().ReverseMap();
        }
    }
}

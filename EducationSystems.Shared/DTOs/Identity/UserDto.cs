using EducationSystems.Models.Enums;

namespace EducationSystems.Shared.DTOs.Identity
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public UserType Type { get; set; }
    }
}

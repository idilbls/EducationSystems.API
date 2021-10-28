using EducationSystems.Models.Entities.Core;
using EducationSystems.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationSystems.Models.Entities.Users
{
    [Table("User")]
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
    }
}

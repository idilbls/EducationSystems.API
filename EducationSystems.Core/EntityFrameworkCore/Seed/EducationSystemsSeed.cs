using EducationSystems.Core.Context;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Users;
using EducationSystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.Core.EntityFrameworkCore.Seed
{
    public class EducationSystemsSeed
    {
        private readonly EducationSystemsDbContext _context;

        public EducationSystemsSeed(EducationSystemsDbContext context)
        {
            this._context = context;
        }

        private void Create()
        {
            Adduser(new User() {Name="Ahmet",Surname="Kızıl", Email= "a.kızıl@iku.edu.tr", Number= "1111111110", Password="123qwe", Type= UserType.professor});
            Adduser(new User() { Name = "Zeynep", Surname = "Kızılkaya", Email = "a.kızılkaya@iku.edu.tr", Number = "1111111111", Password = "123qwe", Type = UserType.professor });
            Adduser(new User() { Name = "Cem", Surname = "Solak", Email = "1700005280@stu.iku.edu.tr", Number = "1700005280", Password = "123qwe", Type = UserType.student });
            Adduser(new User() { Name = "Kübra", Surname = "Aşık", Email = "1301020423@stu.iku.edu.tr", Number = "1301020423", Password = "123qwe", Type = UserType.student });
            Adduser(new User() { Name = "Ehlullah", Surname = "Karakurt", Email = "1507010018@stu.iku.edu.tr", Number = "1507010018", Password = "123qwe", Type = UserType.student });

        }

        private void AddLesson(Lesson lesson)
        {
            if (_context.Lessons.Where(c => c.Code == lesson.Code).Count() == 0)
            {
                _context.Lessons.Add(lesson);
            }
        }

        private void Adduser(User user)
        {
            if (_context.Users.Where(c => c.Email == user.Email).Count() == 0)
            {
                _context.Users.Add(user);
            }
        }
    }
}

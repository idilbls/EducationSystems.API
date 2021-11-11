using EducationSystems.Core.Context;
using EducationSystems.Models.Entities.IdentityAuth;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Map;
using EducationSystems.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystems.Core.EntityFrameworkCore
{
    public static class DataSeeding
    {

        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<EducationSystemsDbContext>();
            context.Database.Migrate();

            //if (context.Users.Count() == 0)
            //{
            //    context.Users.AddRangeAsync(
            //        new List<ApplicationUser>()
            //        {
            //        new ApplicationUser() { Name="Ahmet",Surname="Kızıl", Email= "a.kızıl@iku.edu.tr", Number= "1111111110", Password="123qwe", Type= UserType.professor},
            //        new ApplicationUser() { Name = "Zeynep", Surname = "Kızılkaya", Email = "a.kızılkaya@iku.edu.tr", Number = "1111111111", Password = "123qwe", Type = UserType.professor },
            //        new ApplicationUser() { Name = "Cem", Surname = "Solak", Email = "1700005280@stu.iku.edu.tr", Number = "1700005280", Password = "123qwe", Type = UserType.student },
            //        new ApplicationUser() { Name = "Kübra", Surname = "Aşık", Email = "1301020423@stu.iku.edu.tr", Number = "1301020423", Password = "123qwe", Type = UserType.student },
            //        new ApplicationUser() { Name = "Ehlullah", Surname = "Karakurt", Email = "1507010018@stu.iku.edu.tr", Number = "1507010018", Password = "123qwe", Type = UserType.student }
            //        }
            //  );
            //}

            if (context.UserLessonMaps.Count() == 0)
            {
                context.UserLessonMaps.AddRangeAsync
                (
                    new List<UserLessonMap>()
                    {
                        new UserLessonMap(){UserId=3,LessonId=1,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=2,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=3,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=4,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=5,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=6,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=7,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=8,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=9,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=10,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=11,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=12,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=13,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=14,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=15,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=16,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=17,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=18,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=19,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=3,LessonId=20,StatusType=StatusType.Attendance},

                        new UserLessonMap(){UserId=4,LessonId=1,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=2,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=3,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=4,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=5,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=6,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=7,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=8,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=9,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=10,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=11,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=12,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=13,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=14,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=15,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=16,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=17,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=18,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=19,StatusType=StatusType.Attendance},
                        new UserLessonMap(){UserId=4,LessonId=20,StatusType=StatusType.Attendance},
                    }
                );
            }

            if (context.Lessons.Count() == 0)
            {
                context.Lessons.AddRangeAsync
                    (
                    new List<Lesson>()
                    {
                        new Lesson() {Code="CSE5031",Title="Operating Systems", ProfessorId=1,Date= new DateTime(2022, 1, 1, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE5031",Title="Operating Systems", ProfessorId=1,Date= new DateTime(2022, 1, 3, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE5031",Title="Operating Systems", ProfessorId=1,Date= new DateTime(2022, 1, 7, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE5031",Title="Operating Systems", ProfessorId=1,Date= new DateTime(2022, 1, 9, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE5031",Title="Operating Systems", ProfessorId=1,Date= new DateTime(2022, 1, 12, 09, 0, 0, 000) },

                        new Lesson() {Code="CSE0437",Title="Data Communication", ProfessorId=2,Date= new DateTime(2022, 1, 2, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0437",Title="Data Communication", ProfessorId=2,Date= new DateTime(2022, 1, 4, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0437",Title="Data Communication", ProfessorId=2,Date= new DateTime(2022, 1, 8, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0437",Title="Data Communication", ProfessorId=2,Date= new DateTime(2022, 1, 10, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0437",Title="Data Communication", ProfessorId=2,Date= new DateTime(2022, 1, 13, 09, 0, 0, 000) },

                        new Lesson() {Code="CSE0463",Title="Software Quality & Testing", ProfessorId=1,Date= new DateTime(2022, 2, 13, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0463",Title="Software Quality & Testing", ProfessorId=1,Date= new DateTime(2022, 2, 15, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0463",Title="Software Quality & Testing", ProfessorId=1,Date= new DateTime(2022, 2, 18, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0463",Title="Software Quality & Testing", ProfessorId=1,Date= new DateTime(2022, 2, 20, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE0463",Title="Software Quality & Testing", ProfessorId=1,Date= new DateTime(2022, 2, 24, 09, 0, 0, 000) },

                        new Lesson() {Code="CSE8090",Title="Graduate Project", ProfessorId=2,Date= new DateTime(2022, 2, 11, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE8090",Title="Graduate Project", ProfessorId=2,Date= new DateTime(2022, 2, 16, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE8090",Title="Graduate Project", ProfessorId=2,Date= new DateTime(2022, 2, 21, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE8090",Title="Graduate Project", ProfessorId=2,Date= new DateTime(2022, 2, 23, 09, 0, 0, 000) },
                        new Lesson() {Code="CSE8090",Title="Graduate Project", ProfessorId=2,Date= new DateTime(2022, 2, 25, 09, 0, 0, 000) },


                    }
               );
            }
            context.SaveChangesAsync();
        }
    }
}

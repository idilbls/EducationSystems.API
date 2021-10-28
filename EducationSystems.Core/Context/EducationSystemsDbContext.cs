using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Map;
using EducationSystems.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EducationSystems.Core.Context
{
    public class EducationSystemsDbContext : DbContext
    {
        public EducationSystemsDbContext(DbContextOptions<EducationSystemsDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserLessonMap> UserLessonMaps { get; set; }
    }
}

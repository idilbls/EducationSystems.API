using EducationSystems.Models.Entities.IdentityAuth;
using EducationSystems.Models.Entities.Lessons;
using EducationSystems.Models.Entities.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationSystems.Core.Context
{
    public class EducationSystemsDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, int>
    {
        public EducationSystemsDbContext(DbContextOptions<EducationSystemsDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<UserLessonMap> UserLessonMaps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lesson>();
            builder.Entity<UserLessonMap>();
            
        }
    }
}

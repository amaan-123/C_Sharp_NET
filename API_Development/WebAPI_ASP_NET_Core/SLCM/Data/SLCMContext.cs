using Microsoft.EntityFrameworkCore;
using SLCM.Models;

namespace SLCM.Data
{
    public class SLCMContext : DbContext
    {
        public SLCMContext(DbContextOptions<SLCMContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Tawheed", LastName = "K", Email = "one@gmail.com", PhoneNumber = "9876543210", Department = "CS", Year = 2, GPA = 3.2, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true },
            new Student { Id = 2, FirstName = "Chad", LastName = "L", Email = "multi@gmail.com", PhoneNumber = "8976543210", Department = "EE", Year = 3, GPA = 2.5, EnrollmentDate = DateTime.UtcNow.AddYears(-2), IsActive = true },
            new Student { Id = 3, FirstName = "Laddu", LastName = "M", Email = "petu@gmail.com", PhoneNumber = "9856543210", Department = "CS", Year = 1, GPA = 1.8, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true }
                );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        //public DbSet<SchoolRepository> SchoolRepositories { get; set; }//TODO
    }
}

using Microsoft.EntityFrameworkCore;
using SLCM.Models;

namespace SLCM.Data
{
    public static class Seeder
    {
        public static async Task SeedAsync(IServiceProvider services, CancellationToken ct = default)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Ensure DB created and migrations applied (defensive)
            await db.Database.MigrateAsync(ct);

            // Seed Students if empty
            if (!await db.Students.AnyAsync(ct))
            {
                var students = new[]
                {
                    new Student { FirstName = "Tawheed", LastName = "K", Email = "one@gmail.com", PhoneNumber = "9876543210", Department = "CS", Year = 2, GPA = 3.2, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true },
                    new Student { FirstName = "Chad", LastName = "L", Email = "multi@gmail.com", PhoneNumber = "8976543210", Department = "EE", Year = 3, GPA = 2.5, EnrollmentDate = DateTime.UtcNow.AddYears(-2), IsActive = true },
                    new Student { FirstName = "Laddu", LastName = "M", Email = "petu@gmail.com", PhoneNumber = "9856543210", Department = "CS", Year = 1, GPA = 1.8, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true }
                };

                db.Students.AddRange(students);
            }

            // Seed Courses if empty
            if (!await db.Courses.AnyAsync(ct))
            {
                var courses = new[]
                {
                    new Course { CourseCode = "CS101", CourseName = "Intro to CS", Credits = 3, Department = "CS", Instructor = "Prof A" },
                    new Course { CourseCode = "EE201", CourseName = "Circuits", Credits = 4, Department = "EE", Instructor = "Prof B" }
                };

                db.Courses.AddRange(courses);
            }

            await db.SaveChangesAsync(ct);
        }
    }
}

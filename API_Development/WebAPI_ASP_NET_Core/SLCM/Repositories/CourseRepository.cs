using Microsoft.EntityFrameworkCore;
using SLCM.Data;
using SLCM.Models;

namespace SLCM.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _db;
        public CourseRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Course>> GetAllAsync() => await _db.Courses.AsNoTracking().ToListAsync();

        public async Task<Course?> GetByIdAsync(int id) => await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Course> CreateAsync(Course course)
        {

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            var existing = await _db.Courses.FindAsync(course.Id);
            if (existing == null) return false;

            existing.CourseCode = course.CourseCode;
            existing.CourseName = course.CourseName;
            existing.Credits = course.Credits;
            existing.Department = course.Department;
            existing.Instructor = course.Instructor;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Courses.FindAsync(id);
            if (existing == null) return false;
            _db.Courses.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CourseCodeExistsAsync(string courseCode, int? exceptId = null)
        {
            return await _db.Courses.AnyAsync(c => c.CourseCode.Equals(courseCode, System.StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || c.Id != exceptId.Value));
        }

        public async Task<IEnumerable<Course>> GetByDepartmentAsync(string department)
        {
            return await _db.Courses.Where(c => string.Equals(c.Department, department, System.StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
    }
}

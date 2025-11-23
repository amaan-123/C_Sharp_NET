using SLCM.Data;
using SLCM.Models;
namespace SLCM.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private static readonly object _lock = new();

        public IEnumerable<Course> GetAll() => SchoolData.Courses;

        public Course? GetById(int id) => SchoolData.Courses.FirstOrDefault(c => c.Id == id);

        public Course Create(Course course)
        {
            lock (_lock)
            {
                var newId = SchoolData.Courses.Any() ? SchoolData.Courses.Max(c => c.Id) + 1 : 1;
                course.Id = newId;
                SchoolData.Courses.Add(course);
                return course;
            }
        }

        public bool Update(Course course)
        {
            lock (_lock)
            {
                var existing = GetById(course.Id);
                if (existing == null) return false;
                existing.CourseCode = course.CourseCode;
                existing.CourseName = course.CourseName;
                existing.Credits = course.Credits;
                existing.Department = course.Department;
                existing.Instructor = course.Instructor;
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = GetById(id);
                if (existing == null) return false;
                return SchoolData.Courses.Remove(existing);
            }
        }

        public bool CourseCodeExists(string courseCode, int? exceptId = null)
            => SchoolData.Courses.Any(c => c.CourseCode.Equals(courseCode, System.StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || c.Id != exceptId.Value));

        public IEnumerable<Course> GetByDepartment(string department)
            => SchoolData.Courses.Where(c => string.Equals(c.Department, department, System.StringComparison.OrdinalIgnoreCase));
    }
}

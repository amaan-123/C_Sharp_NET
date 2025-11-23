using SLCM.Models;

namespace SLCM.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        Course Create(Course course);
        bool Update(Course course);
        bool Delete(int id);
        bool CourseCodeExists(string courseCode, int? exceptId = null);
        IEnumerable<Course> GetByDepartment(string department);
    }
}

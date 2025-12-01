using SLCM.Models;

namespace SLCM.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        Task<bool> CourseCodeExistsAsync(string courseCode, int? exceptId = null);
        Task<IEnumerable<Course>> GetByDepartmentAsync(string department);
    }
}

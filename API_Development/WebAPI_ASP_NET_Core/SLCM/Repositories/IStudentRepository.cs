using SLCM.Models;
namespace SLCM.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Student>> GetByDepartmentAsync(string department);
        Task<IEnumerable<Student>> GetByYearAsync(int year);
        Task<bool> EmailExistsAsync(string email, int? exceptId = null);
    }
}

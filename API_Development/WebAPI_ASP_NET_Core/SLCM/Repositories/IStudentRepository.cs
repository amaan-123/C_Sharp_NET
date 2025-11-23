using SLCM.Models;
namespace SLCM.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        Student Create(Student student);
        bool Update(Student student);
        bool Delete(int id);
        IEnumerable<Student> GetByDepartment(string department);
        IEnumerable<Student> GetByYear(int year);
        bool EmailExists(string email, int? exceptId = null);
    }
}

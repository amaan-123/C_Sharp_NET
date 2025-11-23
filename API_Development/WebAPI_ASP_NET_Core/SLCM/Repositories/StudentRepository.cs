using SLCM.Data;
using SLCM.Models;
namespace SLCM.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static readonly object _lock = new();
        public IEnumerable<Student> GetAll() => SchoolData.Students;

        public Student? GetById(int id) => SchoolData.Students.FirstOrDefault(s => s.Id == id);

        public Student Create(Student student)
        {
            lock (_lock)
            {
                var newId = SchoolData.Students.Any() ? SchoolData.Students.Max(s => s.Id) + 1 : 1;
                student.Id = newId;
                SchoolData.Students.Add(student);
                return student;
            }
        }

        public bool Update(Student student)
        {
            lock (_lock)
            {
                var existing = GetById(student.Id);
                if (existing == null) return false;
                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.Email = student.Email;
                existing.PhoneNumber = student.PhoneNumber;
                existing.Department = student.Department;
                existing.Year = student.Year;
                existing.GPA = student.GPA;
                existing.IsActive = student.IsActive;
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var existing = GetById(id);
                if (existing == null) return false;
                return SchoolData.Students.Remove(existing);
            }
        }

        public IEnumerable<Student> GetByDepartment(string department)
            => SchoolData.Students.Where(s => string.Equals(s.Department, department, System.StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Student> GetByYear(int year)
            => SchoolData.Students.Where(s => s.Year == year);

        public bool EmailExists(string email, int? exceptId = null)
            => SchoolData.Students.Any(s => s.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || s.Id != exceptId.Value));
    }
}

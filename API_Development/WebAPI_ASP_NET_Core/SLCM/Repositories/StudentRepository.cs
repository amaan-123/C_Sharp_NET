using Microsoft.EntityFrameworkCore;
using SLCM.Data;
using SLCM.Models;
namespace SLCM.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;
        public StudentRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Student>> GetAllAsync() =>
            await _db.Students.AsNoTracking().ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) =>
           await _db.Students.FindAsync(id);

        public async Task<Student> CreateAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var existing = await _db.Students.FindAsync(student.Id);
            if (existing == null) return false;

            existing.FirstName = student.FirstName;
            existing.LastName = student.LastName;
            existing.Email = student.Email;
            existing.PhoneNumber = student.PhoneNumber;
            existing.Department = student.Department;
            existing.Year = student.Year;
            existing.GPA = student.GPA;
            existing.IsActive = student.IsActive;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _db.Students.FindAsync(id);
            if (existing == null) return false;
            _db.Students.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetByDepartmentAsync(string department)
            => await _db.Students
            .Where(s => string.Equals(s.Department, department, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();

        public async Task<IEnumerable<Student>> GetByYearAsync(int year)
            => await _db.Students
            .Where(s => s.Year == year)
            .ToListAsync();

        //public async Task<bool> EmailExistsAsync(string email, int? exceptId = null)
        //    => await _db.Students.AnyAsync(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || s.Id != exceptId.Value));//modified
        public async Task<bool> EmailExistsAsync(string email, int? exceptId = null) =>
            await _db.Students.AnyAsync(s => s.Email.ToLower() == email.ToLower() && (!exceptId.HasValue || s.Id != exceptId));

    }
}

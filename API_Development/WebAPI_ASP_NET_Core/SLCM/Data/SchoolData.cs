using SLCM.Models;

namespace SLCM.Data
{
    public static class SchoolData
    {
        //public static List<Student> Students = new List<Student>()
        //{
        //    new Student { Id = 1, Name = "Aisha", Email = "aisha@example.com", Phone = "1111111111" },
        //    new Student { Id = 2, Name = "Ravi", Email = "ravi@example.com", Phone = "2222222222" },
        //    new Student { Id = 3, Name = "Meena", Email = "meena@example.com", Phone = "3333333333" }

        //};

        //public static Student? GetById(int id) => Students.FirstOrDefault(s => s.Id == id);


        public static List<Student> Students { get; } = new List<Student>
        {
            new Student { Id = 1, FirstName = "Tawheed", LastName = "K", Email = "one@gmail.com", PhoneNumber = "9876543210", Department = "CS", Year = 2, GPA = 3.2, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true },
            new Student { Id = 2, FirstName = "Chad", LastName = "L", Email = "multi@gmail.com", PhoneNumber = "8976543210", Department = "EE", Year = 3, GPA = 2.5, EnrollmentDate = DateTime.UtcNow.AddYears(-2), IsActive = true },
            new Student { Id = 3, FirstName = "Laddu", LastName = "M", Email = "petu@gmail.com", PhoneNumber = "9856543210", Department = "CS", Year = 1, GPA = 1.8, EnrollmentDate = DateTime.UtcNow.AddYears(-1), IsActive = true }
        };

        public static List<Course> Courses { get; } = new List<Course>
        {
            new Course { Id = 1, CourseCode = "CS101", CourseName = "Intro to CS", Credits = 3, Department = "CS", Instructor = "Prof A" },
            new Course { Id = 2, CourseCode = "EE201", CourseName = "Circuits", Credits = 4, Department = "EE", Instructor = "Prof B" }
        };
    }
}

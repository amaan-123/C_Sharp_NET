namespace SLCM.Models
{
    public static class SchoolRepository
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student { Id = 1, Name = "Aisha", Email = "aisha@example.com", Phone = "1111111111" },
            new Student { Id = 2, Name = "Ravi", Email = "ravi@example.com", Phone = "2222222222" },
            new Student { Id = 3, Name = "Meena", Email = "meena@example.com", Phone = "3333333333" }

        };

        public static Student? GetById(int id) => Students.FirstOrDefault(s => s.Id == id);
    }
}

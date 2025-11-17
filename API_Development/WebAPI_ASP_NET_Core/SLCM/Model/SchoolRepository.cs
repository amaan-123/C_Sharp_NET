namespace SLCM.Model
{
    public static class SchoolRepository
    {
        public static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Tawheed", Email = "one@gmail.com", Phone = "9876543210" },
            new Student { Id = 2, Name = "Chad", Email = "multi@gmail.com", Phone = "8976543210" },
            new Student { Id = 3, Name = "Laddu", Email = "petu@gmail.com", Phone = "9856543210" }
        };
    }
}

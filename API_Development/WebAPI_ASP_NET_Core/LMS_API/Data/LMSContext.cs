using LMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.Data
{
    public class LMSContext : DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> opts) : base(opts) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        // configure relations and seed simple data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Jane", LastName = "Austen", DateOfBirth = new DateTime(1775, 12, 16), Email = "jane.austen@example.com", Biography = "English novelist." },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25), Email = "george.orwell@example.com", Biography = "English novelist and essayist." },
                new Author { Id = 3, FirstName = "Mary", LastName = "Shelley", DateOfBirth = new DateTime(1797, 8, 30), Email = "mary.shelley@example.com", Biography = "English novelist, author of Frankenstein." }
            );

            // Seed books (must reference Author Ids)
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pride and Prejudice", ISBN = "1111111111111", Pages = 432, PublishedDate = new DateTime(1813, 1, 28), Price = 9.99m, IsAvailable = true, AuthorId = 1 },
                new Book { Id = 2, Title = "Emma", ISBN = "2222222222222", Pages = 320, PublishedDate = new DateTime(1815, 12, 25), Price = 8.50m, IsAvailable = true, AuthorId = 1 },
                new Book { Id = 3, Title = "1984", ISBN = "3333333333333", Pages = 328, PublishedDate = new DateTime(1949, 6, 8), Price = 12.50m, IsAvailable = false, AuthorId = 2 },
                new Book { Id = 4, Title = "Animal Farm", ISBN = "4444444444444", Pages = 112, PublishedDate = new DateTime(1945, 8, 17), Price = 7.90m, IsAvailable = true, AuthorId = 2 },
                new Book { Id = 5, Title = "Frankenstein", ISBN = "5555555555555", Pages = 280, PublishedDate = new DateTime(1818, 1, 1), Price = 11.00m, IsAvailable = true, AuthorId = 3 }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Hari Puttar",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Parody",
                    Price = 7.99M,
                    Rating = "PG-13"
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "E"
                }

            );
            // existing sample movies first (or skip)
            for (int i = 1; i <= 200; i++)
            {
                context.Movie.Add(new Movie
                {
                    Title = $"HHHRRRMMMM {i}",
                    ReleaseDate = DateTime.Now.AddDays(-i * 30),
                    Genre = i % 3 == 0 ? "Comedy" : (i % 3 == 1 ? "Drama" : "Action"),
                    Price = 4.99m + (i % 10),
                    Rating = (i % 2 == 0) ? "PG" : "R"
                });
            }
            context.SaveChanges();
        }
    }
}
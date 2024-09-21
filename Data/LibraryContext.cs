using asp_mvc_hello_bookrental.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc_hello_bookrental.Data
{
    public class LibraryContext : DbContext
    {
        // Database context for DI-container
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<BookModel> Books { get; set; }

        // Populating database table with mock data
        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new LibraryContext(
                    serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
                {
                    // Delete mock data
                    if (context.Books.Any())
                    {
                        context.Books.RemoveRange(context.Books);
                        context.SaveChanges();

                        context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('[Books]', RESEED, 0)"); // fixed issue with continuous index, reset identity
                    }

                    context.Books.AddRange(
                        new BookModel { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", Year = 1925, IsRented = false },
                        new BookModel { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Year = 1960, IsRented = false },
                        new BookModel { Title = "1984", Author = "George Orwell", Genre = "Dystopian", Year = 1949, IsRented = false },
                        new BookModel { Title = "Moby-Dick", Author = "Herman Melville", Genre = "Adventure", Year = 1851, IsRented = false },
                        new BookModel { Title = "War and Peace", Author = "Leo Tolstoy", Genre = "Historical", Year = 1869, IsRented = false },
                        new BookModel { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", Year = 1951, IsRented = false },
                        new BookModel { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Year = 1937, IsRented = false },
                        new BookModel { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", Year = 1813, IsRented = false },
                        new BookModel { Title = "The Odyssey", Author = "Homer", Genre = "Epic", Year = -700, IsRented = false },
                        new BookModel { Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Genre = "Philosophical", Year = 1880, IsRented = false }
                    );
                    context.SaveChanges();
                }
            }
        }

    }
}

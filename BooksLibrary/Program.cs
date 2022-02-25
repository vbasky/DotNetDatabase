using BooksLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var authors = GetFakeData();

            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            var options = new DbContextOptionsBuilder<BooksContext>()
                            .UseSqlite(configuration.GetConnectionString("BooksLibrary"), b => b.MigrationsAssembly("EFCore"))
                            .Options;

            using var db = new BooksContext(options);

            //db.Database.EnsureCreated();

            //db.Database.EnsureDeleted();

            //db.Database.EnsureCreated();

            //db.Authors.AddRange(authors);

            //db.SaveChanges();

            //var recentBooks = from b in db.Books
            //                  where b.YearOfPublication > 1950
            //                  select b;

            var recentBooks = db.Books.Where(b => b.YearOfPublication > 1950);

            foreach (var book in recentBooks.Include(b => b.Author))
            {
                Console.WriteLine($"{book} is by ... {book.Author.Name}");
            }
        }

        private static IEnumerable<Author> GetFakeData()
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Name = "Jane Esther",
                    Books = new List<Book>
                    {
                       new Book {Title = "Emma", YearOfPublication= 1856 },
                       new Book {Title = "Persuasion", YearOfPublication= 1916 }
                    }
                },
                new Author
                {
                    Name = "Richard Roost",
                    Books = new List<Book>
                    {
                       new Book {Title = "Flyer", YearOfPublication= 2019 },
                       new Book {Title = "Facet Peacock", YearOfPublication= 1987 }
                    }
                }
            };

            return authors;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BooksLibrary
{
    public class BooksContext: DbContext
    {
        public BooksContext()
        {

        }

        public BooksContext(DbContextOptions<BooksContext> options) :base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=./MyLocalDB.db");
        //}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

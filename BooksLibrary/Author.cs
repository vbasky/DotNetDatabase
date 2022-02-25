using System.Collections.Generic;

namespace BooksLibrary
{
    public class Author
    {
        public Author()
        {          
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

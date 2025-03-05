using GraphQLBooksApi.Models;

namespace GraphQLBooksApi.bin
{
    public class Query
    {
        public IEnumerable<Book> GetBooks() => new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin" },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt" }
        };
    }

}
using GraphQLBooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBooksApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Book> Books => Set<Book>();
    }
}
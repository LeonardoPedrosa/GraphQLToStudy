using GraphQLBooksApi.Data;
using GraphQLBooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBooksApi.GraphQL;

public class Mutation
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public Mutation(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Book> AddBookAsync(string title, string author)
    {
        using var context = _contextFactory.CreateDbContext();
        var book = new Book { Title = title, Author = author };
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }
}

using GraphQLBooksApi.Data;
using GraphQLBooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBooksApi.GraphQL;

public class Query
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public Query(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks()
    {
        var context = _contextFactory.CreateDbContext();
        return context.Books;
    }
}

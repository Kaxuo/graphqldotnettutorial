using System.Linq;
using graphqldotnettutorial.Data;
using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Data;

namespace graphQL_dotnet.GraphQL
{
    public class Query
    {
        // This is where it allows you do a query on a table
        [UseDbContext(typeof(AppDbContext))]
        // Walk through the graph to pull the child object
        // [UseProjection] not needed anymore thanks to Types ( resolvers )
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        // Walk through the graph to pull the child object
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
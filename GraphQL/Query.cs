using System.Linq;
using graphqldotnettutorial.Data;
using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Data;

namespace graphQL_dotnet.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}
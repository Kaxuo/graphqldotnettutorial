using System.Linq;
using graphqldotnettutorial.Data;
using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Types;

namespace graphqldotnettutorial.GraphQL.Platforms
{
    // Allow Queries on the table platform
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");
            descriptor.Field(p => p.LicenseKey).Ignore();
            descriptor.Field(p => p.Commands).ResolveWith<Resolvers>(p => p.GetCommands(default!, default!)).UseDbContext<AppDbContext>().Description("This is the List of available commands for this platform");
        }

        // Allow graphql to find the child object
        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}
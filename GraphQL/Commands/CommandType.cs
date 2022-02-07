using System.Linq;
using graphqldotnettutorial.Data;
using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Types;

namespace graphqldotnettutorial.GraphQL.Commands
{
    // Allows GraphQl Query on the table command
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");
            descriptor.Field(c => c.Platform).ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!)).UseDbContext<AppDbContext>().Description("This is the platform to which the command belongs");
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}
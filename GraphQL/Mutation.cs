using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using graphqldotnettutorial.Data;
using graphqldotnettutorial.GraphQL.Commands;
using graphqldotnettutorial.GraphQL.Platforms;
using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace graphqldotnettutorial.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input,
            [ScopedService] AppDbContext context,
            // Added with subscriptions
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };
            context.Platforms.Add(platform);
            // cancellation token added for subscriptions
            await context.SaveChangesAsync(cancellationToken);
            // Added for Subscriptions
            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);
            return new AddPlatformPayload(platform);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = new Command
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };
            context.Commands.Add(command);
            await context.SaveChangesAsync();
            return new AddCommandPayload(command);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteCommandPayload> DeleteCommandAsync(DeleteCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = context.Commands.Find(input.id);
            context.Commands.Remove(command);
            await context.SaveChangesAsync();
            return new DeleteCommandPayload(command);
        }
    }
}
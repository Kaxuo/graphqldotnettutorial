using graphqldotnettutorial.Models;
using HotChocolate;
using HotChocolate.Types;

namespace graphqldotnettutorial.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}
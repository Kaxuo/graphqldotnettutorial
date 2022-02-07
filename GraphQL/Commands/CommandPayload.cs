using graphqldotnettutorial.Models;

namespace graphqldotnettutorial.GraphQL.Commands
{
    public record AddCommandPayload(Command command);
    public record DeleteCommandPayload(Command command);
}
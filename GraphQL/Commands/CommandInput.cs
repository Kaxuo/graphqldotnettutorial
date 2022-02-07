namespace graphqldotnettutorial.GraphQL.Commands
{
    public record AddCommandInput(string HowTo, string CommandLine, int PlatformId);
    public record DeleteCommandInput(int id);
}
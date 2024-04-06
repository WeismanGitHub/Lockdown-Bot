namespace Server.Commands;

using DSharpPlus.SlashCommands;

public class MessageAnalyticsCommands : ApplicationCommandModule
{
    [SlashCommand("Messages", "Count the total amount of messages.")]
    public async Task Messages(InteractionContext ctx)
    {
        Console.WriteLine(ctx.Guild.Name);
        await ctx.CreateResponseAsync("hello world!");
    }
}

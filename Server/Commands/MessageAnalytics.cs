using DSharpPlus.SlashCommands;

namespace Server;

public class MessageAnalyticsCommands : ApplicationCommandModule
{
    [SlashCommand("messages", "Count the total amount of messages.")]
    public async Task Messages(InteractionContext ctx)
    {
        Console.WriteLine(ctx.Guild.Name);
        await ctx.CreateResponseAsync("hello world!");
    }
}

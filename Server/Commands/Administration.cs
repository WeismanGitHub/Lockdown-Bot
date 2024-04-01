namespace Server.Commands;

using DSharpPlus.SlashCommands;

public class AdministrationCommands : ApplicationCommandModule
{
    [SlashCommand("settings", "Modify the settings.")]
    public async Task Settings(InteractionContext ctx)
    {
        Console.WriteLine(ctx.Guild.Name);
        await ctx.CreateResponseAsync("hello world!");
    }
}

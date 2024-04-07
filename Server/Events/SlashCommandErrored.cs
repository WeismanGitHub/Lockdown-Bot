namespace Server.Events;

using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.EventArgs;

public static class SlashCommandErrored
{
    public static async Task Handler(SlashCommandsExtension _, SlashCommandErrorEventArgs e)
    {
        Console.WriteLine(e);
    }
}

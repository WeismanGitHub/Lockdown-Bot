namespace Server.Bot.Events;

using DSharpPlus.EventArgs;
using Server.Bot;

public static class ClientErrored
{
    public static async Task Handler(DiscordClient _, ClientErrorEventArgs e)
    {
        var errorEmbed = EmbedUtilities.CreateErrorEmbed(e.Exception);
        Console.WriteLine(errorEmbed);

        //if (e.Handled)

        //      await e.Context.CreateResponseAsync(errorEmbed);
    }
}

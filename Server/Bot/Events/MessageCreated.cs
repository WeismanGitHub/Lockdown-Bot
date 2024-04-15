namespace Server.Bot.Events;

using DSharpPlus.EventArgs;
using Server.Database;

public static class MessageCreated
{
    public static async Task Handler(DiscordClient _, MessageCreateEventArgs e)
    {
        // Guild and Author are actually nullable.
        if (e.Guild is null || e.Author is null)
        {
            return;
        }

        // Check cache to see if we want to record messages for this guild.

        var messageService = new MessageService();

        await messageService.SaveMessage(e.Message.Convert());
    }
}

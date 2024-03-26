using DSharpPlus.EventArgs;

namespace Server.Events;

public static class MessageCreate
{
    public static async Task Handler(DiscordClient _, MessageCreateEventArgs e)
    {
        Console.WriteLine(e.Author.Username);
    }
}

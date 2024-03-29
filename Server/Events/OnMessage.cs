namespace Server.Events;

using DSharpPlus.EventArgs;

public static class MessageCreate
{
    public static async Task Handler(DiscordClient _, MessageCreateEventArgs e)
    {
        Console.WriteLine(e.Author.Username);
    }
}

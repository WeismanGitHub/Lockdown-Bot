namespace Server.Bot.Events;

using DSharpPlus.EventArgs;

public static class MessageCreated
{
    public static async Task Handler(DiscordClient _, MessageCreateEventArgs e)
    {
        Console.WriteLine(e.Author.Username);
    }
}

namespace Server.Extensions;

using DSharpPlus.Entities;
using Server.Database;

public static class Extensions
{
    public static IEnumerable<Message> Convert(this IEnumerable<DiscordMessage> messages)
    {
        return messages.Select(msg => new Message()
        {
            Bot = msg.Author.IsBot,
            GuildId = msg.Channel.Guild.Id.ToString(),
            CreatedAt = msg.CreationTimestamp,
            MessageId = msg.Id.ToString(),
            TextLength = msg.Content.Length,
            UserId = msg.Author.Id.ToString()
        });
    }
}

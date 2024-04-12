namespace Server.Extensions;

using DSharpPlus.Entities;
using Server.Database;

public static class Extensions
{
    public static Message Convert(this DiscordMessage message)
    {
        if (message?.Channel?.Guild is null)
        {
            throw new Exception("Message must be from a server.");
        }
        else if (message?.Author is null)
        {
            throw new Exception("Message must have an author");
        }

        return new Message()
        {
            ChannelId = message.ChannelId.ToString(),
            Bot = message.Author.IsBot,
            GuildId = message.Channel.Guild.Id.ToString(),
            CreatedAt = message.CreationTimestamp,
            MessageId = message.Id.ToString(),
            TextLength = message.Content.Length,
            UserId = message.Author.Id.ToString()
        };
    }
}

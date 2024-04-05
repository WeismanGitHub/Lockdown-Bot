using DSharpPlus.Entities;

namespace Server;

public static class EmbedUtilities
{
    public static DiscordEmbedBuilder CreateBuilder()
    {
        return new DiscordEmbedBuilder().WithColor(new DiscordColor("cccccc"));
    }

    public static DiscordEmbedBuilder CreateErrorEmbed(string? description)
    {
        return new DiscordEmbedBuilder()
            .WithColor(new DiscordColor("FF0000"))
            .WithTitle("An Error Occurred!")
            .WithDescription(description);
    }
}

using DSharpPlus.Entities;

namespace Server;

public static class EmbedUtilities
{
    public static readonly DiscordColor White = new("cccccc");
    public static readonly DiscordColor Red = new("FF0000");

    public static DiscordEmbedBuilder CreateBuilder()
    {
        return new DiscordEmbedBuilder().WithColor(White);
    }

    public static DiscordEmbedBuilder CreateErrorEmbed(string? description)
    {
        return new DiscordEmbedBuilder()
            .WithColor(Red)
            .WithTitle("An Error Occurred!")
            .WithDescription(description);
    }
}

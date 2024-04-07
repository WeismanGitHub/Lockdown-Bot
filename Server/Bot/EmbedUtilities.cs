using DSharpPlus.Entities;

namespace Server.Bot;

public static class EmbedUtilities
{
    public static readonly DiscordColor White = new("cccccc");
    public static readonly DiscordColor Red = new("FF0000");

    public static DiscordEmbedBuilder CreateBuilder(string? title, string? description = null)
    {
        return new DiscordEmbedBuilder()
            .WithColor(White)
            .WithTitle(title)
            .WithDescription(description);
    }

    public static DiscordEmbedBuilder CreateErrorEmbed(string? description)
    {
        return new DiscordEmbedBuilder()
            .WithColor(Red)
            .WithTitle("An Error Occurred!")
            .WithDescription(description);
    }
}

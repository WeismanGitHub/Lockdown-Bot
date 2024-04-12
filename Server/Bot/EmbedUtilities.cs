using DSharpPlus.Entities;

namespace Server.Bot;

public static class EmbedUtilities
{
    public static readonly DiscordColor White = new("cccccc");
    public static readonly DiscordColor Red = new("FF0000");

    public static DiscordEmbedBuilder CreateBuilder(string? title, string? description = null)
    {
        var embed = new DiscordEmbedBuilder().WithColor(White);

        if (title != null)
            embed.Title = title;
        if (description != null)
            embed.Description = description;

        return embed;
    }

    public static DiscordEmbedBuilder CreateErrorEmbed(Exception e)
    {
        return new DiscordEmbedBuilder()
            .WithColor(Red)
            .WithTitle("An Error Occurred!")
            .WithDescription(e.Message);
    }
}

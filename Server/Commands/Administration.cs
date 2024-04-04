namespace Server.Commands;

using System.Runtime.InteropServices;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Server.Database;

public class AdministrationCommands : ApplicationCommandModule
{
    public GuildService GuildService { private get; set; } // Implied public setter.

    [SlashCommand("settings", "Modify the settings.")]
    public async Task Settings(
        InteractionContext ctx,
        [Option("Visibility", "Decide who can see server analytics.")] Visibility? visibility = null
    )
    {
        Guild? guild;

        if (visibility != null)
        {
            guild = new Guild()
            {
                GuildId = ctx.Guild.Id.ToString(),
                Visibility = (Visibility)visibility
            };

            await GuildService.UpsertGuild(guild);
        }
        else
        {
            guild = await GuildService.GetGuild(ctx.Guild.Id.ToString());
        }

        await ctx.CreateResponseAsync(
            new DiscordEmbedBuilder()
                .WithTitle($"Settings for ${ctx.Guild.Name}")
                .AddField("Visibility", guild?.Visibility.ToString() ?? "Unknown")
        );
    }
}

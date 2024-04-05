namespace Server.Commands;

using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Server;
using Server.Database;

public class AdministrationCommands : ApplicationCommandModule
{
    public required GuildService GuildService { private get; set; }

    [SlashCommand("settings", "Modify the settings."), GuildOnly]
    public async Task Settings(
        InteractionContext ctx,
        [Option("Visibility", "Decide who can see server analytics.")]
            Visibility? visibility = null,
        [Option("Viewer Role", "Set a viewer role.")] DiscordRole? viewerRole = null
    )
    {
        var guildId = ctx.Guild.Id.ToString();
        Guild guild = await GuildService.GetGuild(guildId) ?? new Guild() { GuildId = guildId };

        var changes = visibility != null || viewerRole != null;
        var hasPermissions =
            ctx.Guild.OwnerId == ctx.User.Id
            || ctx.Guild.CurrentMember.Permissions.HasPermission(Permissions.Administrator);

        if (hasPermissions && changes)
        {
            guild.Visibility = visibility ?? guild.Visibility;
            guild.ViewerRoleId = viewerRole?.Id.ToString();

            await GuildService.UpsertGuild(guild);
        }

        await ctx.CreateResponseAsync(
            EmbedUtilities
                .CreateBuilder()
                .WithTitle($"Settings for ${ctx.Guild.Name}")
                .AddField("Visibility", guild?.Visibility.ToString() ?? "Unknown")
        );
    }
}

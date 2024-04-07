﻿namespace Server.Commands;

using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Server;
using Server.Database;
using Server.Extensions;

public class AdministrationCommands : ApplicationCommandModule
{
    public required GuildService GuildService { private get; set; }
    public required MessageService MessageService { private get; set; }

    [SlashCommand("Settings", "Modify the settings."), GuildOnly]
    public async Task Settings(
        InteractionContext ctx,
        [Option("Visibility", "Decide who can see server analytics.")]
            Visibility? visibility = null,
        [Option("Viewer-Role", "Set a viewer role.")] DiscordRole? viewerRole = null
    )
    {
        var guildId = ctx.Guild.Id.ToString();
        var guild = await GuildService.GetGuild(guildId);

        var changes = visibility != null || viewerRole != null;
        var hasPermissions =
            ctx.Guild.OwnerId == ctx.User.Id
            || ctx.Guild.CurrentMember.Permissions.HasPermission(Permissions.Administrator);

        if (hasPermissions && changes)
        {
            guild ??= new Guild() { GuildId = guildId };

            guild.Visibility = visibility ?? guild.Visibility;
            guild.ViewerRoleId = viewerRole?.Id.ToString();

            await GuildService.UpsertGuild(guild);
        }

        if (guild == null)
        {
            await ctx.CreateResponseAsync(
                EmbedUtilities.CreateErrorEmbed("This server has not been set up yet.")
            );
            return;
        }

        await ctx.CreateResponseAsync(
            EmbedUtilities
                .CreateBuilder($"Settings for {ctx.Guild.Name}")
                .AddField("Visibility", guild?.Visibility.ToString() ?? "Unknown"),
            true
        );
    }

    [GuildOnly]
    [SlashCommand("Index", "Save the messages sent in this server to the database.")]
    public async Task Index(InteractionContext ctx)
    {
        var total = 0;
        await ctx.CreateResponseAsync(EmbedUtilities.CreateBuilder("This may take a while."));
        await ctx.Channel.TriggerTypingAsync();

        foreach (var channel in ctx.Guild.Channels)
        {
            if (channel.Value.Type != ChannelType.Text)
                continue;

            var messages = await channel.Value.GetMessagesAsync();
            await MessageService.InsertMessages(messages.Convert());
            total += messages.Count;

            if (messages == null)
                continue;

            while (messages.Count == 100)
            {
                await ctx.Channel.TriggerTypingAsync();

                messages = await channel.Value.GetMessagesBeforeAsync(messages.Last().Id);
                await MessageService.InsertMessages(messages.Convert());
                total += messages.Count;
            }
        }

        await ctx.EditResponseAsync(
            new DiscordWebhookBuilder().AddEmbed(
                EmbedUtilities.CreateBuilder(
                    "Finished indexing this server!",
                    $"Indexed {total} messages."
                )
            )
        );
    }
}

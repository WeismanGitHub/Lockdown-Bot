namespace Server.Bot.Events;

using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.EventArgs;

public static class SlashCommandErrored
{
    public static async Task Handler(SlashCommandsExtension _, SlashCommandErrorEventArgs e)
    {
        var embed = EmbedUtilities.CreateErrorEmbed(e.Exception);

        if (
            e.Context.Interaction.ResponseState == DiscordInteractionResponseState.Replied
            || e.Context.Interaction.ResponseState == DiscordInteractionResponseState.Deferred
        )
        {
            await e.Context.FollowUpAsync(new DiscordFollowupMessageBuilder().AddEmbed(embed));
        }
        else
        {
            await e.Context.CreateResponseAsync(EmbedUtilities.CreateErrorEmbed(e.Exception));
        }
    }
}

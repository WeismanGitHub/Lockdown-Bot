﻿using DSharpPlus.Entities;

namespace Server;

public static class EmbedUtilities
{
    public static DiscordEmbedBuilder CreateBuilder()
    {
        return new DiscordEmbedBuilder().WithColor(new DiscordColor("cccccc"));
    }
}
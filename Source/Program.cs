﻿using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder().AddUserSecrets<Configuration>().Build();

var token = config.GetSection("Token").Value;

var discord = new DiscordClient(
    new DiscordConfiguration()
    {
        Token = token,
        TokenType = TokenType.Bot,
        Intents = DiscordIntents.Guilds
    }
);

var slash = discord.UseSlashCommands();

await discord.ConnectAsync();
await Task.Delay(-1);
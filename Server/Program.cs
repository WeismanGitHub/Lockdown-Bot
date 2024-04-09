using DSharpPlus.SlashCommands;
using Microsoft.OpenApi.Models;
using Server.Api;
using Server.Bot;
using Server.Bot.Commands;
using Server.Bot.Events;
using Server.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
var config = builder.Configuration.Get<Configuration>()!;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(config);
builder.Services.AddSwaggerGen(x =>
    x.SwaggerDoc(
        "v1",
        new OpenApiInfo()
        {
            Title = "Discord Analytics API",
            Description = "placeholder",
            Version = "1.0"
        }
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSecurityHeaders(SecurityHeadersPolicy.Create());
app.UseHsts();

app.MapFallbackToFile("/index.html");
app.UseStaticFiles();
app.MapControllers();

var client = new DiscordClient(
    new DiscordConfiguration()
    {
        MinimumLogLevel = LogLevel.Information,
        Token = config.Token,
        TokenType = TokenType.Bot,
        // Add DiscordIntents.MessageContents to read message content
        Intents = DiscordIntents.Guilds | DiscordIntents.GuildMessages
    }
);

var slash = client.UseSlashCommands(
    new SlashCommandsConfiguration()
    {
        Services = new ServiceCollection()
            .AddScoped<GuildService>()
            .AddScoped<MessageService>()
            .BuildServiceProvider()
    }
);

slash.RegisterCommands<MessageAnalyticsCommands>();
slash.RegisterCommands<AdministrationCommands>();

new ClientUtilities(slash, client).RegisterCommands().RegisterEvents();

await client.ConnectAsync();
app.Run();

using DSharpPlus.SlashCommands;
using Microsoft.OpenApi.Models;
using Server.Commands;
using Server.Database;
using Server.Events;

var services = new ServiceCollection().AddScoped<GuildService>();

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

app.MapFallbackToFile("/index.html");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var discord = new DiscordClient(
    new DiscordConfiguration()
    {
        MinimumLogLevel = LogLevel.Information,
        Token = config.Token,
        TokenType = TokenType.Bot,
        // Add DiscordIntents.MessageContents to read message content
        Intents = DiscordIntents.Guilds | DiscordIntents.GuildMessages
    }
);

var slash = discord.UseSlashCommands(
    new SlashCommandsConfiguration() { Services = services.BuildServiceProvider() }
);
slash.RegisterCommands<MessageAnalyticsCommands>();

discord.MessageCreated += MessageCreate.Handler;

await discord.ConnectAsync();
app.Run();

using DSharpPlus;
using Microsoft.OpenApi.Models;

//using DSharpPlus.SlashCommands;

var builder = WebApplication.CreateBuilder(args);
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
        Token = config.Token,
        TokenType = TokenType.Bot,
        Intents = DiscordIntents.Guilds
    }
);

//var slash = discord.UseSlashCommands();

await discord.ConnectAsync();
app.Run();

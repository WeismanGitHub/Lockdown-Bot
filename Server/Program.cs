using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
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

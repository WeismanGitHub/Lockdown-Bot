using DSharpPlus;

//using DSharpPlus.SlashCommands;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration.Get<Configuration>()!;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(config);
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

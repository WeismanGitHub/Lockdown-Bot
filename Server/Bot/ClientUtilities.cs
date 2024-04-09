using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using DSharpPlus.SlashCommands;
using Server.Bot.Events;

namespace Server.Bot;

public class ClientUtilities
{
    private readonly SlashCommandsExtension slash;
    private readonly DiscordClient client;

    public ClientUtilities(SlashCommandsExtension slash, DiscordClient client)
    {
        this.slash = slash;
        this.client = client;
    }

    public ClientUtilities RegisterCommands()
    {
        var commands = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith("Server.Bot.Commands"))
            .Where(s => s.Name.Contains("Commands"));

        foreach (var command in commands)
        {
            slash.RegisterCommands(command);
        }

        return this;
    }

    public ClientUtilities RegisterEvents()
    {
        client.MessageCreated += MessageCreated.Handler;
        slash.SlashCommandErrored += SlashCommandErrored.Handler;

        return this;
    }
}

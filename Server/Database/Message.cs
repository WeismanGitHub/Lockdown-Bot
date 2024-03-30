namespace Server.Database;

public class Message
{
    public required string MessageId { get; set; }
    public required string UserId { get; set; }
    public required string GuildId { get; set; }
    public DateTime CreatedAt { get; set; }
}

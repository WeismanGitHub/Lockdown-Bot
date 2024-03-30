namespace Server.Database;

public enum Visibility
{
    Members,
    Admins
}

public class Guild
{
    public required string GuildId { get; set; }
    public Visibility Visibility { get; set; }
    public DateTime CreatedAt { get; set; }
}

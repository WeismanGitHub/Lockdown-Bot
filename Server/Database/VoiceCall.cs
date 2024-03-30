namespace Server.Database;

public class VoiceCall
{
    public required string ChannelId { get; set; }
    public required string GuildId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
// figure out if/how you want to store users. maybe do it individually per person.

namespace Server.Database;

using System.ComponentModel.DataAnnotations;

public class VoiceCall
{
    [Key, Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required string ChannelId { get; set; }

    [Required]
    public required string GuildId { get; set; }

    [Required]
    public required Guild Guild { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime? EndTime { get; set; }
}
// figure out if/how you want to store users. maybe do it individually per person.

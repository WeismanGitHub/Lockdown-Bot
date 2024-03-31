namespace Server.Database;

using System.ComponentModel.DataAnnotations;

public enum Visibility
{
    Members,
    Admins
}

public class Guild
{
    [Key, Required]
    public required string GuildId { get; set; }

    [Required]
    public required Visibility Visibility { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public required ICollection<Message> Messages { get; set; }
    public required ICollection<VoiceCall> VoiceCalls { get; set; }
}

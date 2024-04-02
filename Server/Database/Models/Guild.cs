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
    public ICollection<Message> Messages { get; set; } = [];
    public ICollection<VoiceCall> VoiceCalls { get; set; } = [];
}

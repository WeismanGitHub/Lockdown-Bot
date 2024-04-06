namespace Server.Database;

using System.ComponentModel.DataAnnotations;

public enum Visibility
{
    Members,
    Admins,
    ViewerRole
}

public class Guild
{
    [Key, Required]
    public required string GuildId { get; set; }

    [Required]
    public Visibility Visibility { get; set; } = Visibility.Members;

    public string? ViewerRoleId { get; set; }

    public string? AdminRoleId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public ICollection<Message> Messages { get; set; } = [];
    public ICollection<VoiceCall> VoiceCalls { get; set; } = [];
}

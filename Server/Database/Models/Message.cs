namespace Server.Database;

using System.ComponentModel.DataAnnotations;

public class Message
{
    [Key, Required]
    public required string MessageId { get; set; }

    [Required]
    public required bool Bot { get; set; }

    [Required]
    public required string UserId { get; set; }

    [Required]
    public required Guild Guild { get; set; }

    [Required]
    public required string GuildId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

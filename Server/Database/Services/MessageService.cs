namespace Server.Database;

public class MessageService
{
    public AnalyticsContext _context { get; set; } = new();

    public async Task InsertMessage(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}

namespace Server.Database;

public class MessageService
{
    public AnalyticsContext _context { get; set; } = new();

    public async Task InsertMessages(IEnumerable<Message> message)
    {
        _context.Messages.BulkInsert(message);
        await _context.SaveChangesAsync();
    }

    public async Task SaveMessage(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}

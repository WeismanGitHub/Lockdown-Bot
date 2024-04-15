using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Server.Database;

namespace Server.Bot;

public class GuildCache
{
    private readonly MemoryCache _cache;
    private readonly AnalyticsContext _context;

    public GuildCache(long limit = 1_000_000, double compactionPercentage = 100)
    {
        _cache = new MemoryCache(
            new MemoryCacheOptions()
            {
                SizeLimit = limit,
                CompactionPercentage = compactionPercentage
            }
        );
    }

    public async Task<bool> GuildIsSetup(string guildId)
    {
        return await _cache.GetOrCreateAsync(
            guildId,
            async (entry) =>
            {
                var guildRowExists = await _context.Guilds.AnyAsync((g) => g.GuildId == guildId);
                entry.SetValue(guildRowExists);
            }
        );
    }
}

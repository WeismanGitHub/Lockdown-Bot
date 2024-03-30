namespace Server.Database;

using System;
using Microsoft.EntityFrameworkCore;

public class AnalyticsContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<VoiceCall> VoiceCalls { get; set; }

    public string DbPath { get; }

    public AnalyticsContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "analytics.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guild>().HasMany(g => g.Messages).WithOne(m => m.Guild);
        modelBuilder.Entity<Guild>().HasMany(g => g.VoiceCalls).WithOne(vc => vc.Guild);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}

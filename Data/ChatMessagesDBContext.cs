using Microsoft.EntityFrameworkCore;
using SimpleChat.Models;

namespace SimpleChat.Data;

public class ChatMessagesDBContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ChatMessagesDBContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("DBFile"));
    }

    public DbSet<ChatMessage> ChatMessages { get; set; }
}
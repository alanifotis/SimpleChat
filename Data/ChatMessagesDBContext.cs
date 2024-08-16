using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Models;

namespace SimpleChat.Data;

public class ChatMessagesDBContext : DbContext
{
    public ChatMessagesDBContext(DbContextOptions<ChatMessagesDBContext> options)
        : base(options)
    {
    }

    public DbSet<ChatMessage> ChatMessages { get; set; }

    public DbSet<User> Users { get; set; }

}
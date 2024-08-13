using System.ComponentModel.DataAnnotations;

namespace SimpleChat.Models;

public class User {
    public int Id { get; set; }

    public required string UserName { get; set; }

    public required string SentMessage { get; set;} 

    public bool Valid { get; set; }
    
    public ICollection<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
}
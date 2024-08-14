using System.ComponentModel.DataAnnotations;

namespace SimpleChat.Models;

public class User () {
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string SentMessage { get; set;} = string.Empty;

    public bool Valid { get; set; }
    
    public ICollection<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
}
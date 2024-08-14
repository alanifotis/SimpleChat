using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleChat.Models;

public class ChatMessage {
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required, MinLength(3)]
    public required string Message { get; set; }

}
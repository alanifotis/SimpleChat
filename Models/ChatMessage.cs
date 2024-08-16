using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleChat.Models;

public class ChatMessage {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [
        Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a message"),
        DataType(DataType.MultilineText),
        Column("chat_message", TypeName = "VARCHAR(255)"),
    ]
    public string Message { get; set; } = string.Empty; 

}
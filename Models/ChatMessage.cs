using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleChat.Models;

public class ChatMessage {
    [Key, Column("id")]
    public Guid Id { get; set; } 

    public Guid SetID() { return Guid.NewGuid(); }

    [Column("user_id")]
    public long UserID { get; set; }

    [
        Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a message"),
        DataType(DataType.MultilineText),
        Column("chat_message", TypeName = "VARCHAR(255)"),
    ]
    public string Message { get; set; } = string.Empty; 

    [ForeignKey("UserID")]
    public User User { get; init; } = null!;

}
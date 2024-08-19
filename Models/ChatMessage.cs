using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleChat.Models;

public class ChatMessage {
    [Key, Column("id")]
    public ulong Id { get; set; }

    [Column("user_id")]
    public ulong? UserID { get; set; } = null;

    [
        Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a message"),
        DataType(DataType.MultilineText),
        Column("chat_message", TypeName = "TEXT"),
    ]
    public string Message { get; set; } = string.Empty; 

    [ForeignKey("UserID")]
    public User User { get; set; } = null!;

}
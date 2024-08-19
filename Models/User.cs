using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace SimpleChat.Models;

 [Table("user")]
public class User () {
    [
        Key, 
        Column("id"),
        DatabaseGenerated(DatabaseGeneratedOption.Identity)
    ]
    public long Id { get; set; }

    [
        Required, 
        MinLength(2, ErrorMessage = "Two characters are required to set your UserName."),
        MaxLength(50, ErrorMessage = "Max allowed length is 50 Characters."),
        Column("user_name")
    ]
    public string UserName { get; set; } = string.Empty;

    [   
        Required, 
        MinLength(6, ErrorMessage = "Min. 6 characters are required"), 
        MaxLength(50, ErrorMessage = "Max. allowed length is 50 Characters."), 
        Column("password"),
        DataType(DataType.Password)
    ]

    public string Password { get; set; } = string.Empty;

    [
        Required,
        DataType(DataType.MultilineText),
        Column("chat_message", TypeName = "VARCHAR(255)"),
        MaxLength(ErrorMessage = "Exceeded max length. Try separating your message.")
    ]
    
    public ICollection<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
}
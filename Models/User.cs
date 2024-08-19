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
    public ulong Id { get; set; }

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
    
    public ICollection<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
}
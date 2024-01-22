#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class Message
{
    [Key]
    public int MessageId { get; set; }
    
    [Required(ErrorMessage="Message is required")]
    public string MyMessage { get;set; }

    public int? UserId {get;set;}
    public User? Writer {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Comment>? CommentOnMessage {get;set;} = new List<Comment>();
}
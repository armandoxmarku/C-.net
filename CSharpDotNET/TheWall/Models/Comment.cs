#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheWall.Models;
public class Comment
{
    [Key]
    public int CommentId { get; set; }
    
    [Required(ErrorMessage="Comment is required")]
    public string MyComment { get;set; }

    public int? UserId {get;set;}
    public int? MessageId {get;set;}
    public User? UserCommenter {get;set;}
    public Message? MessageCommented {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
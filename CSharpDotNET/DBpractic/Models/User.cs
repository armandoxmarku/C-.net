#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DBpractic.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(3,ErrorMessage ="emri me i gjate se 3 shkronja")]
    public string Name { get; set; } 
    public int Height { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
                

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using BeltPrep.Models;
namespace BeltPrep.Models;
public class Guest
{
    [Key]
    public int GuestId { get; set; }
    public int? UserId {get;set;}
    public int? EventId {get;set;}
    
    [MinLength(4,ErrorMessage = "pershkrimi me i gjate se 4 shkronja")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? UserGuest {get;set;}
    public Event? Event {get;set;}

}
    
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class Guest{
      [Key]
    public int GuestId { get; set; }

    public int? UserId { get; set; }
    public User? GuestUser { get; set; }
    public int? WeddingId { get; set; }
    public Wedding? Wedding { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;        
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

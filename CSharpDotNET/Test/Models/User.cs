#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HobbyHub.Models;
namespace HobbyHub.Models;

public class User
{
    [Key]
    public int UserId { get; set; }


    [Required(ErrorMessage ="First Name is required")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName {get; set;}


    [Required(ErrorMessage ="Last Name is required")]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    
    public string LastName {get; set;}


    [Required]
   
    public string Username { get; set; }
  

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }    


    [NotMapped]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}
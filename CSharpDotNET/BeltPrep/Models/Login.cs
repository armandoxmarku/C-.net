#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltPrep.Models;

public class Login {
    [Required(ErrorMessage = "Email address is required.")]
    
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;
using Test.Models;

namespace Test.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
    
        public string LoginUsername { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string LoginPassword { get; set; }
    }
}

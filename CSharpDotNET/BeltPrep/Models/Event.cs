#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltPrep.Models;
public class Event
{
    [Key]
    public int EventId { get; set; }
    public int? UserId {get;set;}
    [Required]
    [UniqueName]
    public string Name { get; set; } 
    [MinLength(4,ErrorMessage = "pershkrimi me i gjate se 4 shkronja")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? Creator {get;set;}
    public List<Guest>? Guests {get;set;}
}
  public class UniqueNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Name is required!");
        }
    
    	// This will connect us to our database since we are not in our Controller
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Events.Any(e => e.Name == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Name must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}
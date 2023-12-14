using System;
using System.ComponentModel.DataAnnotations;
namespace FormSubmition.Models;
#pragma warning disable CS8618
 public class User{
    [Required(ErrorMessage ="Name is required")]
    [MinLength(3,ErrorMessage ="Name must be at least 2 characters long")]
    public string Name  {get; set;}
    [Required(ErrorMessage = "email is required")]
    [EmailAddress(ErrorMessage ="Enter  a valid email addres")]
    public string Email  {get; set;}
    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [PastDate(ErrorMessage = "Date of Birth must be in the past.")]
    
    public DateTime? DateOfBirth   {get; set;}

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Favorite Odd Number is required.")]
    [OddNumber(ErrorMessage = "Favorite Odd Number must be a whole odd number.")]
    public int? FavoriteOddNumber { get; set; }

 }

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime dateValue;
            if (DateTime.TryParse(value.ToString(), out dateValue))
            {
                if (dateValue.Date >= DateTime.Now.Date)
                {
                    return new ValidationResult(ErrorMessage ?? "Date of Birth must be in the past.");
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }
        }

        return ValidationResult.Success;
    }
}



public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            int number;
            if (int.TryParse(value.ToString(), out number))
            {
                if (number % 2 != 1)
                {
                    return new ValidationResult(ErrorMessage ?? "The number must be a whole odd number.");
                }
            }
            else
            {
                return new ValidationResult("Invalid number format.");
            }
        }

        return ValidationResult.Success;
    }
}


#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;
public class Chef
{
    public int ChefId { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    [PastDate(ErrorMessage = "Date of Birth must be in the past")]
    [MinimumAge(18, ErrorMessage = "Chef must be at least 18 years old")]
    public DateTime? DateOfBirth { get; set; }

    public List<Dish>? Dishes { get; set; }
      public int Age {
        get
        {
            if (DateOfBirth.HasValue)
            {
                DateTime now = DateTime.Now;
                int age = now.Year - DateOfBirth.Value.Year;

                if (now < DateOfBirth.Value.AddYears(age))
                {
                    age--;
                }

                return age;
            }
            return 0;
        }
    }
}



[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            var age = CalculateAge(dateOfBirth);

            if (age < _minimumAge)
            {
                return new ValidationResult($"The minimum age is {_minimumAge} years.");
            }
        }

        return ValidationResult.Success;
    }

    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date && date > DateTime.Now)
        {
            return new ValidationResult("The date must be in the past.");
        }

        return ValidationResult.Success;
    }
}


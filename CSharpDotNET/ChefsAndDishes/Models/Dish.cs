#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;
public class Dish
{
    public int DishId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories { get; set; }

    public int ChefId { get; set; }
    public Chef? Chef { get; set; }
}

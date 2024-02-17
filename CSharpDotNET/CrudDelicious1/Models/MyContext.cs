#pragma warning disable CS8618
using CrudDelicious1.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudDelicious1.Models;

public class MyContext : DbContext 
{   

    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<Dish> Dishes { get; set; } 
}
#pragma warning disable CS8618
using connectDB.Models;
using Microsoft.EntityFrameworkCore;
namespace connectDB.Models;

public class MyContext : DbContext 
{   

    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> User { get; set; } 
}
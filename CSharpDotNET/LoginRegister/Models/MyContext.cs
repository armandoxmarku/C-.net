#pragma warning disable CS8618
using LoginRegister.Models;
using Microsoft.EntityFrameworkCore;
namespace LoginRegister.Models;
public class MyContext : DbContext 
{    
    public MyContext(DbContextOptions options) : base(options) { }    
     
      public DbSet<User> Users {get;set;}
}

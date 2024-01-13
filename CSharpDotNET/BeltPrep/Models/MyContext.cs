#pragma warning disable CS8618
using BeltPrep.Models;
using Microsoft.EntityFrameworkCore;
namespace BeltPrep.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events {get;set;}
    public DbSet<Guest> Guests {get;set;}
}
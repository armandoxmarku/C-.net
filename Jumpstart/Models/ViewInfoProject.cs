#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Jumpstart.Models;
namespace Jumpstart.Models;


public class ViewInfoProject
{
    
    public Project? Project{get;set;}
    public List<Project>? Projects{get;set;}
    public Suporters? suporters{get;set;}
    public int SupportersCount { get; set; }
    public int TotalDonations { get; set; }
    public TimeSpan UntilEnd { get; set; }
    public bool UserHasSupported { get; set; }
    
}
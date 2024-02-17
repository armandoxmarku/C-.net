#pragma warning disable CS8618
namespace mvcpraktik.Models;
using System.ComponentModel.DataAnnotations;
public class User
{
    [Required(ErrorMessage ="emri duhet te plotesohet")]
    [MinLength(4 , ErrorMessage ="gjatesia me e madhe se 3 shkronja")]
    public string firstName  {get;set;}
    [Required]
    public string lastName  {get;set;}
    [Required]
    public string Location  {get;set;}
    [Range(13,120,ErrorMessage ="duhet te jesh 13+")]
    public int age   {get;set;}
}
// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace RazorFun.Controllers;   
public class HomeController : Controller 
{
    [HttpGet("")]
     public ViewResult Index()        
    {            
     return View("Index");  
    }  
}
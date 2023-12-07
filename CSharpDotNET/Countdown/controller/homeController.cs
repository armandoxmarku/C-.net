// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Countdown.Controllers;   
public class homeController : Controller  
{
    [HttpGet("")]
    public ViewResult Index(){
        return View("index");
    }
}
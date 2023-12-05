// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Portfoglio.Controllers;   
public class PortfoglioController : Controller  
{
    [HttpGet("")]
    public ViewResult Index(){
        return View("index");

    }
    [HttpGet("projects")]
    public ViewResult Projects(){
        return View("projects");
    }
    [HttpGet("contact")]
    public ViewResult Contacts(){
        return View("contacts");

    }
}
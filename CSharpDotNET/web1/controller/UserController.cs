// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace web1.Controllers;   
public class UserController : Controller   // Remember inheritance?    
{      
    [HttpGet("")] // We will go over this in more detail on the next page    
     // We will go over this in more detail on the next page
    public ViewResult Index()        
    {            
     return View("Index");  
    }  

    [HttpGet("user/{name}")] 
    public ViewResult User(string name){
        ViewBag.test= "test";
        ViewBag.name = name;
        return View("user");
    }

      
}
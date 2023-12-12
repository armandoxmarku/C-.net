using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
         ViewBag.message = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Hic sunt, magni repellat eligendi facere reiciendis ad repellendus, ab debitis corporis dolor mollitia unde culpa veniam accusantium harum magnam saepe ipsum?";
        return View();

    }
    [HttpGet("/numbers")]
    public IActionResult Numbers()
    {
        Random rand = new Random();
            int[] arrNum = new int[10];
            for(int i = 0; i < 10; i++)
            {
                arrNum[i] = rand.Next();
                
            }
            ViewBag.Nums = arrNum;
            return View();
        

    }
     [HttpGet("/user1")]
    public IActionResult User1()
    {
        User user = new User
        {
            fname = "armando",
            lname = "marku"
        };
        ViewBag.User = user;
        return View("Person", user);
    }

    [HttpGet("/user")]
    public IActionResult Users()
    {
        User user = new User
        {
            fname = "armando",
            lname = "marku"
        };
        ViewBag.User = user;
        return View("User1", user);
    }

    [HttpGet("/users")]
    public IActionResult UserAll()
    {
        User Joey = new User
        {
            fname = "Joey",
            lname = "Weber"
        };
        User Nicole = new User
        {
            fname = "Nicole",
            lname = "Weber"
        };
        User Chris = new User
        {
            fname = "Chris",
            lname = "Jager"
        };
        List<User> users = new List<User>()
        {
            Joey, Nicole, Chris
        };
        ViewBag.User = users;
        return View("UsersAll", users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

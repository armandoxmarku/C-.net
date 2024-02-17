using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcpraktik.Models;

namespace mvcpraktik.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("regjistrohu")]
    public IActionResult Regjistrohu()
    {
        return View();
    }
    [HttpPost("createUser")]
    public IActionResult CreateUser( User userData)
    {
        if (ModelState.IsValid)
        {
             return View(userData);
        }
        return View("regjistrohu");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

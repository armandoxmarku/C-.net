using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmition.Models;

namespace FormSubmition.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

      [HttpGet]
        public IActionResult Index()
        {
            var user = new User(); 
            return View(user);
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Succes");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Succes()
        {
            return View();
        }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

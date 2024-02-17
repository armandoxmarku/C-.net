using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudDelicious1.Models;

namespace CrudDelicious1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.listaMedish = _context.Dishes.ToList();
        return View();
    }

    [HttpGet("AddDish")]
    public IActionResult AddDish()
    {
        return View();
    }
    [HttpPost("CreateDish")]
    public IActionResult CreateDish(Dish dishNgaForma)
    {
        if (ModelState.IsValid)
        {
            _context.Add(dishNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        return View("AddDish");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

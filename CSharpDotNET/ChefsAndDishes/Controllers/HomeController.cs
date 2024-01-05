using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

     [HttpGet("")]
        public IActionResult Chefs()
        {
            List<Chef> allChefs = _context.Chef.Include(c => c.Dishes).ToList();
            ViewBag.AllChefs = allChefs;
            return View("Chefs");
        }
    [HttpGet("AddChef")]
    public IActionResult AddChef(){
        return View("AddChef");
    }
    [HttpPost("CreateChef")]
    public IActionResult CreateChef(Chef chef){
        if (ModelState.IsValid)
        {
            _context.Add(chef);
            _context.SaveChanges();
             return RedirectToAction("Chefs");
            
        }
        return View("AddChef");
    }
    [HttpGet("AddDish")]
    public IActionResult AddDish(){
        List<Chef> EveryChef = _context.Chef.ToList();
        ViewBag.AllChefs = EveryChef;
         return View("AddDish");
    }
    [HttpPost]
    public IActionResult CreateDish(Dish dish){
        if (ModelState.IsValid)
        {
           
            _context.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        return View("AddDish");
    }
    [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = _context.Dishes.Include(d => d.Chef).ToList();
            ViewBag.AllDishes = AllDishes;
            return View("Dishes");
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

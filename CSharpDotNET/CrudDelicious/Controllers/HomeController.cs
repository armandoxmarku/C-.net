using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudDelicious.Models;
using CRUDelicious.Models;

namespace CrudDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger , MyContext context)
    {
        _context =context; 
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.Dishes = _context.Dishes.OrderByDescending(e => e.UpdatedAt).ToList();
        return View();
    }
    [HttpGet("dishes/new")]
    public IActionResult AddDish(){
        return View();

    }
    [HttpPost]
    public IActionResult ValidationDish(Dish dish){
        if (ModelState.IsValid)
        {
            _context.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        return View("AddDish");
    }
    [HttpGet("dishes/{itemId}")]
    public IActionResult DetailsDish(int itemId){
        Dish dishDB = _context.Dishes.FirstOrDefault(e => e.DishId == itemId);
        return View(dishDB);
    }
    [HttpGet("dishes/{itemId}/delete")]
    public IActionResult DeleteDish(int itemId ){
         Dish dishDB = _context.Dishes.FirstOrDefault(e => e.DishId ==itemId); 
        _context.Remove(dishDB);
        _context.SaveChanges();
         return RedirectToAction("index");
    }
    [HttpGet("dishes/{itemId}/edit")]
    public IActionResult EditDish(int itemId )
    {
        Dish dishDB = _context.Dishes.FirstOrDefault(e => e.DishId == itemId);
        return View("EditDish",dishDB);
    }
    [HttpPost("dishes/{itemId}/update")]
    public IActionResult Update(Dish dish , int itemId){
        Dish dishDB = _context.Dishes.FirstOrDefault(e => e.DishId == itemId);
        if (ModelState.IsValid)
        {
            dishDB.DishChef = dish.DishChef;
            dishDB.DishTastiness = dish.DishTastiness;
            dishDB.DishName = dish.DishName;
            dishDB.DishCalories = dish.DishCalories;
            dishDB.UpdatedAt = dish.UpdatedAt;
            dishDB.DishDescription = dish.DishDescription;
            _context.SaveChanges();
            return RedirectToAction("DetailsDish", new {itemId = itemId});
        }
        return View("EditDish" ,dishDB);

    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

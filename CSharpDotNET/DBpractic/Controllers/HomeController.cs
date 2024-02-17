using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DBpractic.Models;

namespace DBpractic.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
         ViewBag.allUsers = _context.Users.ToList();
        return View();
    }
    [HttpGet("Register")]
    public IActionResult Register(){
        return View();
    }
    [HttpPost("Create")]
    public IActionResult Create(User useriNgaForm){

        if (ModelState.IsValid)
        {
            _context.Add(useriNgaForm);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

       
        return View("Register");
    }
    [HttpGet("Details/{id}")]
    public IActionResult Details(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        return View(useriNgaDb);
    }
    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        _context.Remove(useriNgaDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpPost("Update/{id}")]
    public IActionResult Update(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        return View(useriNgaDb);
    }
    [HttpGet("Edit/{id}")]
    public IActionResult Edit(User useriNgaForma,int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        useriNgaDb.Name = useriNgaForma.Name;
         useriNgaDb.Description = useriNgaForma.Description;
          useriNgaDb.Height = useriNgaForma.Height;
         useriNgaDb.CreatedAt = DateTime.Now;  
         _context.SaveChanges();
        return View("index");
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

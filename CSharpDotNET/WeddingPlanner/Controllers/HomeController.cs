using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Auth", "Home", null);
        }
    }
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private  MyContext _context;

    public HomeController(ILogger<HomeController> logger ,MyContext context)
    {
        _logger = logger;
        _context =context;
    }

    [SessionCheck]
    public IActionResult Index()
    
    {
        
        ViewBag.weddingTable = _context.Weddings.Include(e => e.Guests).OrderBy(e => e.WeddingDate).ToList();
        return View();
    }
    public IActionResult Auth()
    {
        return View("Auth");
    }
    public IActionResult Register(User useriNgaForma)
    {

        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            useriNgaForma.Password = Hasher.HashPassword(useriNgaForma, useriNgaForma.Password);
            _context.Add(useriNgaForma);
            _context.SaveChanges();
            return RedirectToAction("Auth");
        }
        return View("Auth");

    }
    [HttpPost("Login")]
    public IActionResult Login(Login useriNgaForma)
    {

        if (ModelState.IsValid)
        {

            User useriNgaDB = _context.Users.FirstOrDefault(e => e.Email == useriNgaForma.Email);
            if (useriNgaDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email");
                return View("Auth");
            }

            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(useriNgaForma, useriNgaDB.Password, useriNgaForma.Password);
            if (result == 0)
            {
                ModelState.AddModelError("LoginPassword", "Invalid Password");
                return View("Auth");
            }
            HttpContext.Session.SetInt32("UserId", useriNgaDB.UserId);
            return RedirectToAction("Index");

        }
        return View("Auth");

    }
    

    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Auth");
    }
    [SessionCheck]
    [HttpGet("AddWedding")]
    public IActionResult AddWedding(){
        return View("AddWedding");
    }

    [HttpPost("CreateWedding")]
    public IActionResult CreateWedding(Wedding weddingNgaForm){

        if(ModelState.IsValid){
            

            _context.Add(weddingNgaForm);
            _context.SaveChanges();
            return RedirectToAction("WeddingDetails", new { id = weddingNgaForm.WeddingId });
        }
        return View("AddWedding",weddingNgaForm);
    }
    [SessionCheck]
    [HttpGet("WeddingDetails/{id}")]
    public IActionResult WeddingDetails(int id ){
        Wedding weddingDetails = _context.Weddings
        .Include(g =>g.Guests)
        .ThenInclude(u=>u.GuestUser)
        .FirstOrDefault(w =>w.WeddingId ==id);

        return View("WeddingDetails",weddingDetails);
    }
    [SessionCheck]
    [HttpGet("AttendWedding")]
    public IActionResult AttendWedding (int Id){
        int? UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.userId = UserId;
        Guest GuestFromDb = new Guest();
        GuestFromDb.WeddingId = Id;
        GuestFromDb.UserId = HttpContext.Session.GetInt32("UserId");
        _context.Add(GuestFromDb);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    [SessionCheck]
    [HttpGet("DoNotAttendWedding")]
    public IActionResult DoNotAttendWedding(int Id){
        int? UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.userId = UserId;
        
        Guest GuestFromDb = _context.Guests.FirstOrDefault(e=> e.WeddingId == Id && e.UserId == UserId);
        _context.Remove(GuestFromDb);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    [SessionCheck]
      [HttpGet("DeleteWedding")]
    public IActionResult DeleteWedding(int id){
        int? UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.userId = UserId;

        Wedding deleteWedding = _context.Weddings.Include(e => e.Guests).FirstOrDefault(e=> e.WeddingId == id);
        _context.Remove(deleteWedding);
        _context.SaveChanges();

        return RedirectToAction("Index");
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

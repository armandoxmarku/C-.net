using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers;
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
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger ,MyContext context)
    {
        _logger = logger;
        _context =context;
    }

    
    [HttpGet("Auth")]
    public IActionResult Auth(){
        return View("Auth");

    } public IActionResult Register(User useriNgaForma)
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

            User useriNgaDB = _context.Users
            .FirstOrDefault(e => e.Email == useriNgaForma.LoginEmail);
            if (useriNgaDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email");
                return View("Auth");
            }

            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(useriNgaForma, useriNgaDB.Password, useriNgaForma.LoginPassword);
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
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Auth");
    }
    [SessionCheck]

    public IActionResult Index()
    {    int? userId =  HttpContext.Session.GetInt32("UserId");
        ViewBag.userId = userId;
        User  currentUser = _context.Users.FirstOrDefault(e => e.UserId == userId);
        ViewBag.Name = currentUser;

        ViewBag.AllMessages = _context.Messages.Include(e => e.Writer).Include(e => e.CommentOnMessage).ThenInclude(e => e.UserCommenter).OrderByDescending(e => e.CreatedAt).ToList();
        return View();
    }

    [HttpPost("WriteMessage")]
    public IActionResult WriteMessage(Message messageForm){
        if(ModelState.IsValid){
            messageForm.UserId =HttpContext.Session.GetInt32("UserId");
            _context.Add(messageForm);
            _context.SaveChanges();
             return RedirectToAction("Index");
            
        }
        int? userId =  HttpContext.Session.GetInt32("UserId");
        User  currentUser = _context.Users.FirstOrDefault(e => e.UserId == userId);
        ViewBag.Name = currentUser;
        ViewBag.AllMessages = _context.Messages.Include(e => e.Writer).Include(e => e.CommentOnMessage).ThenInclude(e => e.UserCommenter).ToList();

        return View("Index");
    }
     [SessionCheck]
    [HttpGet]
    public IActionResult DeletePost(int itemId)
    {
        Message Delete = _context.Messages.Include(e => e.CommentOnMessage).FirstOrDefault(e => e.MessageId == itemId);
        _context.Remove(Delete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [SessionCheck]
    [HttpPost]
    public IActionResult PostComment(Comment commentForm, int itemid)
    {
        if (ModelState.IsValid)
        {
            commentForm.UserId = HttpContext.Session.GetInt32("UserId");
            commentForm.MessageId = itemid;
            _context.Add(commentForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        int? userId =  HttpContext.Session.GetInt32("UserId");
        User  currentUser = _context.Users.FirstOrDefault(e => e.UserId == userId);
        ViewBag.Name = currentUser;
        ViewBag.AllMessages = _context.Messages.Include(e => e.Writer).Include(e => e.CommentOnMessage).ThenInclude(e => e.UserCommenter).ToList();
        
        return View("Index");
    }
      [SessionCheck]
    [HttpGet]
    public IActionResult DeleteComment(int itemId)
    {
        Comment Delete = _context.Comments.FirstOrDefault(e => e.CommentId == itemId);
        _context.Remove(Delete);
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

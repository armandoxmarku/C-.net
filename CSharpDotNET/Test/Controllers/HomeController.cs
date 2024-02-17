using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpPost("Register")]
    using Test.Models; // Add the missing using directive

    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // If a User exists with provided email
            if (dbContext.Users.Any(u => u.Username == newUser.Username))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("Username", "Username already in use!");
                // You may consider returning to the View at this point
                return View("Index");
            }
            else
            {
                // Initializing a PasswordHasher object, providing our User class as its
                // type
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                //Save your user object to the database
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("Index");
        }
    }
    [HttpPost("Login")]
    public IActionResult Login(Login userSubmission)
    {
        if (ModelState.IsValid)
        {
            // If inital ModelState is valid, query for a user with provided email
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Username == userSubmission.LoginUsername);
            // If no user exists with provided email
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("LoginUsername", "Invalid Username/Password");
                return View("Index");
            }
            // Initialize hasher object
            var hasher = new PasswordHasher<Login>();
            // varify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
            // result can be compared to 0 for failure
            if (result == 0)
            {
                ModelState.AddModelError("LoginPassword", "Invalid Username/Password");
                return View("Index");
                // handle failure (this should be similar to how "existing email" is
                // handled)
            }
            else
            {
                return RedirectToAction("Success");
            }
        }
        else
        {
            return View("Index");
        }
    }
    [HttpGet("AddPost")]
    public IActionResult AddPost()
    {
        return View("AddPost");
    }

    [HttpPost("CreatePost")]
    public IActionResult CreatePost(Post newPost)
    {
        if (ModelState.IsValid)
        {
            dbContext.Add(newPost);
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }
        else
        {
            return View("AddPost");
        }
    }   
    [HttpGet("posts/{postId}")]
    public IActionResult Post(int postId)
    {
        ViewBag.Post = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
        return View("Post");
    }
    public IActionResult Index()
    {
        ViewBag.AllPosts = dbContext.Posts..ToList();

        return View();
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

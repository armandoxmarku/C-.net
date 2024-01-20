using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Jumpstart.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jumpstart.Controllers;
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

    public HomeController(ILogger<HomeController> logger , MyContext context)
    {
        _context =context;
        _logger = logger;
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
    [HttpGet("AddProject")]
    public IActionResult AddProject()
    {
        return View("AddProject");
    }
    [HttpPost("CreateProject")]
    public IActionResult CreateProject(Project projectFormForm)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (ModelState.IsValid)
        {
            User? creator = _context.Users.FirstOrDefault(u => u.UserId == userId);
            projectFormForm.Creator = creator;
            _context.Projects.Add(projectFormForm);
            _context.SaveChanges();
            return RedirectToAction("ProjectDetails", new { projectId = projectFormForm.ProjectId });

        }
        return View("AddProject");
    }
    [SessionCheck]
    [HttpGet("ProjectDetails/{projectId}")]
    public IActionResult ProjectDetails(int projectId)
    {
        var projectInfo = _context.Projects
            .Where(p => p.ProjectId == projectId)
            .Select(p => new
            {
                Project = p,
                SupportersCount = p.Supporters.Any() ? p.Supporters.Count() : 0,
                TotalDonations = p.Supporters.Any() ? p.Supporters.Sum(s => s.Donations) : 0,
                EndDate = p.EndDate
            })
            .FirstOrDefault();


        ViewInfoProject viewInfoProject = new ViewInfoProject
        {
            Project = projectInfo.Project,
            SupportersCount = projectInfo.SupportersCount,
            TotalDonations = projectInfo.TotalDonations,
            UntilEnd = projectInfo.EndDate - DateTime.Now
        };

        return View("ProjectDetails", viewInfoProject);
    }

    [SessionCheck]
    public IActionResult Index()
    {
        List<Project> allProjects = _context.Projects
                .Include(p => p.Creator)
                .Include(p => p.Supporters)
                    .ThenInclude(s => s.User)
                .ToList();

            foreach (var project in allProjects)
            {
                project.Supporters = project.Supporters
                    .Select(s => new Suporters
                    {
                        User = s.User,
                        Donations = s.Donations
                    })
                    .ToList();
            }
        return View("Index", allProjects);
    }
    [SessionCheck]
    [HttpPost("delete/{projectId}")]
    public IActionResult DeleteProject(int projectId)
    {
        Project? deleteproject= _context.Projects.FirstOrDefault(p => p.ProjectId== projectId);
        if(deleteproject != null)
        {
            _context.Remove(deleteproject);
            _context.SaveChanges();
        }
        
        return RedirectToAction("Index");
    }
    [SessionCheck]
    [HttpPost("support/{projectId}")]
public IActionResult SupportProject(int projectId, ViewInfoProject viewInfoProject, int donations)
{
    int? userId = HttpContext.Session.GetInt32("UserId");

   

    if (!userId.HasValue)
    {
        return RedirectToAction("Login");
    }

    int actualUserId = userId.Value;

    Project supportingProject = _context.Projects.Include(p => p.Creator).FirstOrDefault(p => p.ProjectId == projectId);

    if (DateTime.Now > supportingProject.EndDate)
    {
        return RedirectToAction("ProjectDetails", new { projectId = projectId });
    }

    if (supportingProject.CreatorId == actualUserId)
    {
        return RedirectToAction("ProjectDetails", new { projectId = projectId });
    }
    else
    {
        Suporters newSuporter = new Suporters
        {
            UserId = actualUserId,
            ProjectId = projectId,
            Donations= viewInfoProject.suporters.Donations
        };
        _context.Suporters.Add(newSuporter);
        _context.SaveChanges();

        
        viewInfoProject.UserHasSupported = true;

        
        HttpContext.Session.SetInt32($"UserHasSupported_{actualUserId}_{projectId}", 1);

        return RedirectToAction("ProjectDetails", new { projectId = projectId });
    }
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

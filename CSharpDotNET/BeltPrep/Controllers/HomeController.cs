﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltPrep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using BeltPrep.Models;
using Microsoft.EntityFrameworkCore;

namespace BeltPrep.Controllers;
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            context.Result = new RedirectToActionResult("Auth", "Home", null);
        }
    }
}
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context =context;
    }
    [SessionCheck]
    public IActionResult Index()
    {
          ViewBag.aktivitet = _context.Events.Include(e=>e.Creator).Include(e=>e.Guests).ToList();
        return View();
    }
    [HttpGet("Auth")]
    public IActionResult Auth()
    {
        return View("Auth");
    }
    [HttpPost("Register")]
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

            User useriNgaDB = _context.Users
            .FirstOrDefault(e => e.Email == useriNgaForma.Email);
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
    [HttpGet("LogOut")]
    public IActionResult LogOut(){
        HttpContext.Session.Clear();
        return RedirectToAction("Auth");
    }
    [HttpGet("AddEvent")]
    public IActionResult AddEvent(){
        return View();
    }
    [SessionCheck]
    [HttpPost("CreateEvent")]
    public IActionResult CreateEvent(Event eventForm){
        if (ModelState.IsValid)
        {
            eventForm.UserId=HttpContext.Session.GetInt32("UserId");
            _context.Add(eventForm);
            _context.SaveChanges();
           return RedirectToAction("Index");
        }
        return View("AddEvent");
    }
    [SessionCheck]
    [HttpGet("EventDetails/{id}")]
    public IActionResult EventDetails(int id){
        ViewBag.UserId=HttpContext.Session.GetInt32("UserId");
        ViewBag.aktivitetiNgaDb = _context.Events.Include(e=>e.Creator).Include(e=>e.Guests).FirstOrDefault(e=> e.EventId==id);
        return View("EventDetails");
    }
    [SessionCheck]
     [HttpPost("Merrpjese/{id}")]
    public IActionResult JoinEvent( Guest guest,int id){
        guest.EventId = id;
        guest.UserId=HttpContext.Session.GetInt32("UserId");
         _context.Add(guest);
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
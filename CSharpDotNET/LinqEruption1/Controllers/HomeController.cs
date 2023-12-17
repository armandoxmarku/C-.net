using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqEruption1.Models;

namespace LinqEruption1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Eruption> eruptions = new List<Eruption>()
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };
        Eruption chileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
        ViewBag.ChileEruption = chileEruption;
        var HawaiianEruption = eruptions.FirstOrDefault(e => e.Location =="Hawaiian")?.Volcano ?? "nuk egziston";
        ViewBag.HawaiianEruption = HawaiianEruption;
        var GreenlandEruption = eruptions.FirstOrDefault(e => e.Location =="Greenland")?.Volcano ?? "nuk egziston";
        ViewBag.GreenlandEruption = GreenlandEruption;
        Eruption newZeland = eruptions.FirstOrDefault(e=> e.Location == "New Zealand");
        ViewBag.newZeland = newZeland;
        List<Eruption> elevation2000 = eruptions.Where(e=> e.ElevationInMeters > 2000 ).ToList();
        ViewBag.elevation2000 =elevation2000;
        List<Eruption> eruptionL = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
        ViewBag.eruptionL = eruptionL;
        int eruptionLnr = eruptions.Where(e => e.Volcano.StartsWith("L")).Count();
        int LarteriaMax = eruptions.Max(e=> e.Year);
        ViewBag.eruptionLnr = eruptionLnr;
        ViewBag.LarteriaMax = LarteriaMax;
        Eruption MaxName = eruptions.FirstOrDefault(e=> e.Year == LarteriaMax);
        ViewBag.MaxName = MaxName;
        List<Eruption> eruptionalph = eruptions.OrderBy(e=> e.Volcano).ToList();
        ViewBag.eruptionalph = eruptionalph;
        int sumElv = eruptions.Sum(e=> e.ElevationInMeters);
        bool elvbool = eruptions.Any(e=> e.Year ==2000);
        List<Eruption> threestrv = eruptions.Where(e=> e.Type =="Stratovolcano").Take(3).ToList();
        ViewBag.threestrv = threestrv;
        List<Eruption> eruptions1000 = eruptions.Where(e=> e.Year < 1000).OrderBy(e=> e.Volcano).ToList();
        ViewBag.eruptions1000 =eruptions1000;
        List<string> emrat1000 = eruptions.Where(e=> e.Year < 1000).OrderBy(e=> e.Volcano).Select(e=> e.Volcano).ToList();
        ViewBag.emrat1000 = emrat1000;

     

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

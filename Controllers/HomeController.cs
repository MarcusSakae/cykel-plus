using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RunningApp.ApplicationCore;
using RunningApp.Models;
using RunningApp.Data;
using Microsoft.EntityFrameworkCore;

namespace RunningApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EfContex _context;

    public HomeController(ILogger<HomeController> logger, EfContex context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var runInfos = _context.RunningInfos
            .Include("User")
            .ToList();
        return View(runInfos);
    }

    [HttpPost]
    public ActionResult Register(User user)
    {
        var result = _context.Add(user);
        _context.SaveChanges();
        return View("Thanks", result);
    }
    public IActionResult Register()
    {
        _logger.LogInformation("---Register---");
        return View();
    }

    public IActionResult SavePoint()
    {
        _logger.LogInformation("---SavePoint---");
        return View();
    }

    [HttpPost("info")]
    public ActionResult Point(int userId, int runningInfoId, double x, double y)
    {
        _logger.LogInformation("---x---");
        _logger.LogInformation("---y---");
        _logger.LogInformation("---userId---");
        _logger.LogInformation("---runningInfos---");

        var result = _context.Add(new RunningPointInfo
        {
            X = x,
            Y = y,
            User = _context.Users.Find(userId),
            RunningInfo = _context.RunningInfos.Find(runningInfoId)
        });
        _context.SaveChanges();
        return View("SavePoint");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

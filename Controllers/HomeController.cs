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
        return View("Thanks", user);
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
        _logger.LogInformation("---x---" + x);
        _logger.LogInformation("---y---" + y);
        _logger.LogInformation("---userId---" + userId);
        _logger.LogInformation("---runningInfos---" + runningInfoId);

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

    [HttpPost("GetRunningInfo")]
    public IActionResult GetRunningInfo(DateTime startTime, string track, int tempo, int userId)
    {
        _logger.LogInformation("---startTime---" + startTime);
        _logger.LogInformation("---track---" + track);
        _logger.LogInformation("---tempo---" + tempo);
        _logger.LogInformation("---userid---" + userId);

        var result = _context.Add(new RunningInfo
        {
            StartTime = startTime,
            Track = track,
            Tempo = tempo,
            User = _context.Users.Find(userId)
        });
        _context.SaveChanges();
        return View("InfoCompleted");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

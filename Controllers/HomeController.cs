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

        return View();
    }
    public IActionResult Register()
    {
        _logger.LogInformation("---Register---");
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

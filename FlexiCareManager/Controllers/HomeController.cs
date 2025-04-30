using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FlexiCareManager.Models;

namespace FlexiCareManager.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return RedirectToAction("NotLoggedIn", "Home");
        }
        if (User.IsInRole("PHYSIO"))
        {
            return RedirectToAction("Index", "Patients");
        }
        if (User.IsInRole("PATIENT"))
        {
            return RedirectToAction("Patient", "Home");
        }
        
        return View();
    }
    public IActionResult NotLoggedIn()
    {
        return View();
    }
    public IActionResult Patient()
    {
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!User.Identity!.IsAuthenticated)
        {
            ViewData["Navbar"] = "_NotLoggedInNav";
            RedirectToAction("NotLoggedIn", "Home");
            return;
        }
        if (User.IsInRole("ADMINISTRATOR"))
        {
            ViewData["Navbar"] = "_AdministratorNav";
            return;
        }
        if (User.IsInRole("PHYSIO"))
        {
            ViewData["Navbar"] = "_PhysioNav";
            return;
        }
        if (User.IsInRole("PATIENT"))
        {
            ViewData["Navbar"] = "_NotLoggedInNav";
            RedirectToAction("NotLoggedIn", "Home");
            return;
        }
        
        ViewData["Navbar"] = "_NotLoggedInNav";
    }
}
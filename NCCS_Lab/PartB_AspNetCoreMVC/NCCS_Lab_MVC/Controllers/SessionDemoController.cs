using Microsoft.AspNetCore.Mvc;

namespace NCCS_Lab_MVC.Controllers
{
    // Q18: Server-side state management using Session State
    public class SessionDemoController : Controller
    {
        // Page 1: capture name and store in Session
        [HttpGet]
        public IActionResult SetName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetName(string userName)
        {
            // Store in Session (server-side, keyed to the user's session cookie)
            HttpContext.Session.SetString("UserName", userName);
            return RedirectToAction("GetName");
        }

        // Page 2 (different action): retrieve name back from Session
        [HttpGet]
        public IActionResult GetName()
        {
            string? name = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = name ?? "No name stored in session yet.";
            return View();
        }
    }
}

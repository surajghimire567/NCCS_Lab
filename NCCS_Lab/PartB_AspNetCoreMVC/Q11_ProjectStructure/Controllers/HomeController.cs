using Microsoft.AspNetCore.Mvc;

namespace Q11_ProjectStructure.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

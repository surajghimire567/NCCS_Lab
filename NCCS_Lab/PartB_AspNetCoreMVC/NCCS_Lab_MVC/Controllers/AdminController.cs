using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NCCS_Lab_MVC.Controllers
{
    public class AdminController : Controller
    {
        // Q19: Only users in the "Admin" role can access this action.
        // Unauthenticated users -> redirected to Identity login page.
        // Authenticated but non-Admin users -> 403 Forbidden.
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

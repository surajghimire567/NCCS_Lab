using Microsoft.AspNetCore.Mvc;
using NCCS_Lab_MVC.Models;

namespace NCCS_Lab_MVC.Controllers
{
    // Q12: Controller returning a list of products to a Razor view
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Keyboard", Price = 1500 },
                new Product { Id = 2, Name = "Mouse", Price = 800 },
                new Product { Id = 3, Name = "Monitor", Price = 12000 }
            };

            return View(products); // passes model to Views/Product/Index.cshtml
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NCCS_Lab_MVC.Models;

namespace NCCS_Lab_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // Q13/Q14: GET - display registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Employee());
        }

        // Q13/Q14: POST - submit form, validated via Data Annotations
        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            // ModelState.IsValid runs SERVER-SIDE validation based on
            // the [Required]/[Range]/[EmailAddress] attributes on Employee.
            if (ModelState.IsValid)
            {
                TempData["Message"] = $"Employee {employee.Name} registered successfully!";
                return RedirectToAction("Register");
            }
            // Invalid -> redisplay form with validation messages
            return View(employee);
        }

        // Q15: Custom route maps /employee/details/5 -> Details action, id = 5
        // Route attribute declared here; general pattern also configured in Program.cs
        [HttpGet]
        [Route("employee/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var employee = GetEmployees().FirstOrDefault(employee => employee.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpGet]
        [Route("staff")]
        public IActionResult Staff()
        {
            return View(GetEmployees());
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Ram", Age = 30, Email = "ram@example.com" },
                new Employee { Id = 5, Name = "Hari", Age = 28, Email = "hari@example.com" }
            };
        }
    }
}

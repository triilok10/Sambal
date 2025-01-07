using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeManagement()
        {
            return View();
        }
    }
}

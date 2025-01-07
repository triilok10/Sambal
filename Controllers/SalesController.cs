using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SalesManagement()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WarehouseManagement()
        {
            return View();
        }
    }
}

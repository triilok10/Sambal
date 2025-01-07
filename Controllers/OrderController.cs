using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderManagement()
        {

            return View();
        }
    }
}

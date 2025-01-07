using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class ReturnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReturnManagement()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Sambal.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientsManagement()
        {
            return View();
        }
    }
}

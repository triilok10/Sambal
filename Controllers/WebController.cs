using Microsoft.AspNetCore.Mvc;
using Sambal.Models;

namespace Sambal.Controllers
{
    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WebView()
        {
            List<Web> lstWeb = new List<Web>();
            ViewBag.lstWeb = lstWeb;
            return View();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sambal.AppCode;
using Sambal.Models;
using System.Text;

namespace Sambal.Controllers
{

    public class LoginController : Controller
    {
        #region "Constructor"

        private readonly HttpClient _httpClient;
        private readonly dynamic baseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClsSession _clsSession;
        public LoginController(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IClsSession clsSession)
        {
            _httpClient = httpClient;
            _clsSession = clsSession;
            _httpContextAccessor = httpContextAccessor;
            var request = _httpContextAccessor.HttpContext.Request;
            baseUrl = $"{request.Scheme}://{request.Host.Value}/";
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        #region "Login"

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region "Login Auth"

        [HttpPost]
        public async Task<IActionResult> LoginAuth(Login pLogin)
        {
            try
            {
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Login", "Login");
        }

        #endregion
    }


}

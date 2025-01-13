using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sambal.AppCode;
using Sambal.Models;
using System.Text;

namespace Sambal.Controllers
{
    public class WebController : Controller
    {

        #region "Constructor"

        private readonly HttpClient _httpClient;
        private readonly dynamic baseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClsSession _clsSession;
        public WebController(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IClsSession clsSession)
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

        public IActionResult WebView()
        {
            List<Web> lstWeb = new List<Web>();
            ViewBag.lstWeb = lstWeb;
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult>  AddCategory(Web pWeb, IFormFile CategoryImage)
        {
            Web obj = new Web();
            if (pWeb == null)
            {
                pWeb.Message = "Please pass the required Data";
                pWeb.Status = false;
                return RedirectToAction("", "");
            }
            if (string.IsNullOrWhiteSpace(pWeb.CategoryTitle))
            {
                pWeb.Message = "Please pass the Category Title.";
                pWeb.Status = false;
                return RedirectToAction("", "");
            }
            if (CategoryImage.Length == 0)
            {
                pWeb.Message = "Please pass the Category Image";
                pWeb.Status = false;
                return RedirectToAction("", "");
            }

            //API URL 
            string apiURL = baseUrl + "";

            string Json = JsonConvert.SerializeObject(CategoryImage);
            StringContent con = new StringContent(Json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(apiURL, con);

            return RedirectToAction("", ""); ;
        }

    }
}

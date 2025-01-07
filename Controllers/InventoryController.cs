using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sambal.AppCode;

namespace Sambal.Controllers
{
    [ServiceFilter(typeof(SessionAdmin))]
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DashBoard()
        {
            return View();
        }
    }
    public class SessionAdmin : ActionFilterAttribute
    {
        private readonly IClsSession _clsSession;

        public SessionAdmin(IClsSession clsSession)
        {
            _clsSession = clsSession;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? UserId = _clsSession.GetInt32("UserID");
            string Username = _clsSession.GetString("Username");
            bool IsSystemUser = _clsSession.GetBool("IsSystemUser");
            if (string.IsNullOrEmpty(Username) || UserId == null)
            {
                _clsSession.SetString("LoginAuth", "Auth");
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}

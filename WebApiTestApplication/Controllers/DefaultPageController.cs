using System.Web.Http;
using System.Web.Mvc;

namespace WebApiTestApplication.Controllers
{
    public class DefaultPageController : Controller
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult Index(string from, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                return View();
            }
            ViewBag.Title = "Default page";
            return View();
        }
    }
}
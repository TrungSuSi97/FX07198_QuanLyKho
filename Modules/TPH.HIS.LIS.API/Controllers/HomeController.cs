using System.Web.Mvc;

namespace TPH.LIS.APIWrapper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System.Web.Mvc;
using TPH.HIS.WebAPI.Services;
using TPH.HIS.WebAPI.Services.Impl;

namespace TPH.LIS.APIWrapper.Controllers
{
    public class LisController : Controller
    {
        private readonly IWebAPIService _lisService = new WebAPIServiceImpl();

        [HttpGet]
        public ActionResult Ad()
        {
            return View("~/Views/Lis/index.cshtml");
        }
        [HttpPost]
        public JsonResult UpdatePatient(string data, string token)
        {
            var result = _lisService.UpdatePatientInfo(data, token);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdatePatient(string data)
        {
            var result = _lisService.UpdatePatientInfo(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

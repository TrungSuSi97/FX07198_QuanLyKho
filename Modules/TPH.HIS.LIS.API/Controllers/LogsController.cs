using System.Web.Mvc;
using TPH.LIS.API.Services;
using TPH.LIS.API.Services.Impl;
using TPH.HIS.WebAPI.Models.Logs;

namespace TPH.LIS.APIWrapper.Controllers
{
    public class LogsController: Controller
    {
        private readonly ILogsService _logsService = new LogsServiceImpl();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestLog()
        {
            return View();
        }

        public JsonResult Insert(LogMessageModel message)
        {
            var result = _logsService.Insert(message);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string key)
        {
            var result = _logsService.Delete(key);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(LogFilter filter)
        {
            var result = _logsService.Search(filter);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
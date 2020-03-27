using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
namespace TakeawayFrontUI.Controllers
{
    public class ShowTakeController : Controller
    {
        ShowTakeBLL bll = new ShowTakeBLL();
        // GET: ShowTake
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTake(TakeRequest request)
        {
            return Json(bll.GetTake(request));
        }
    }
}
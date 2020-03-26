using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SDK;

namespace TakeawayFrontUI.Controllers
{
    public class SHOWController : Controller
    {
        ShowBll bll = new ShowBll();
        // GET: SHOW
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult show(ShowMenuInfoRequest showRequest)
        {
            return Json(bll.Show(showRequest));
        }
    }
}
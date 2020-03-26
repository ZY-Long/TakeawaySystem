using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakeawayFrontUI.Controllers
{
    public class TakeawayHomeController : Controller
    {
        // GET: TakeawayHome
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// 404页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFind()
        {
            return View();
        }
    }
}
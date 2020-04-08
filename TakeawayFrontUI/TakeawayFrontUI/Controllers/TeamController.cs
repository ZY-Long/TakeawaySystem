using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakeawayFrontUI.Controllers
{
    public class TeamController : Controller
    {
        
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MEMBER()
        {
            return View();
        }
    }
}
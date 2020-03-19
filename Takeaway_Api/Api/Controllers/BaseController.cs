using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class BaseController : Controller
    {
        
        public ActionResult Index()
        {
            ///玩不明白的东西
            ///1.改东西了，先提交，再拉取，最后推送
            ///2.没改东西，先拉取，再修改，再提交，最后推送
            return View();
        }
    }
}
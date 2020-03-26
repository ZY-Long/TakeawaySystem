using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
namespace TakeawayFrontUI.Controllers
{
    public class ShowCartController : Controller
    {
        ShowCartBLL bll = new ShowCartBLL();
        // GET: ShowCart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCart(GetCartRequest request)
        {
            return Json(bll.GetCart(request));
        }
    }
}
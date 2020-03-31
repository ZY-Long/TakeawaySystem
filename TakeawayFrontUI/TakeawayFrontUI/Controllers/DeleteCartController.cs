using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
namespace TakeawayFrontUI.Controllers
{
    public class DeleteCartController : Controller
    {
        DeleteCartBLL bll = new DeleteCartBLL();
        // GET: DeleteCart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DeleteCartInfo(DeleteCartRequest request)
        {
            return Json(bll.DeleteCart(request));
        }
    }
}
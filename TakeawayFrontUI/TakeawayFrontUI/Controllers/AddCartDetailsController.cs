using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
namespace TakeawayFrontUI.Controllers
{
    public class AddCartDetailsController : Controller
    {
        AddCartBLL bll = new AddCartBLL();
        // GET: AddCartDetails
        public ActionResult AddCartDetails()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCartDetailInfos(AddCartDetailsRequest request)
        {
            AddCartDetailsResponse response = bll.AddCartDetails(request);
            return Json(response);
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CartTran(AddCartDetailsRequest request)
        {
            AddCartDetailsResponse response = bll.CartTran(request);
            return Json(response);
        }

    }
}
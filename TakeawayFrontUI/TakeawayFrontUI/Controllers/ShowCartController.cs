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
        /// <summary>
        /// 模板页
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCart()
        {
            return View();
        }
        /// <summary>
        /// 分布页
        /// </summary>
        /// <returns></returns>
        public ActionResult FenShowCart()
        {
            return View();
        }
        /// <summary>
        /// ajax视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCartDeci()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetCart(GetCartRequest request)
        {
            GetCartResponse response = bll.GetCart(request);
            return Json(response);
        }
    }
}
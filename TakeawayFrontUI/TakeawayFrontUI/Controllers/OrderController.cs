using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;

namespace TakeawayFrontUI.Controllers
{
    public class OrderController : Controller
    {
        OrderBLL bll = new OrderBLL();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 将总价写入session
        /// </summary>
        public JsonResult SessionPrice(decimal Price)
        {

            bool status;
            if (Price > 0)
            {
                Session["Price"] = Price.ToString();
                status = true;
            }
            else
            {
                status = false;
            }
            return Json(status);
        }


        /// <summary>
        /// 生成订单信息
        /// </summary>
        public JsonResult GenerateOrder(GenerateOrderRequest request)
        {
            GenerateOrderResponse response = bll.GenerateOrder(request);
            return Json(response);
        }

        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetOrders(GetOrdersRequest request)
        {
            GetOrdersResponse response = bll.GetOrders(request);
            return Json(response);
        }
    }
}
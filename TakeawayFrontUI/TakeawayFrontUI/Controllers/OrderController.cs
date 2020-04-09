using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
using Newtonsoft.Json;

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
        [HttpPost]
        public JsonResult SessionPrice(decimal Price,string[] Ids )
        {

            bool status;
            if (Price > 0 && Ids!=null)
            {
                Session["Price"] = Price.ToString();
                string json = JsonConvert.SerializeObject(Ids);
                Session["Ids"] = json;
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

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetOrderDetails(GetOrderDetailsRequest request)
        {
            GetOrderDetailsResponse response = bll.GetOrderDetails(request);
            
            return Json(response);
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult OrderTran(GenerateOrderRequest request)
        {
            GenerateOrderResponse response = bll.OrderTran(request);

            return Json(response);
        }
    }
}
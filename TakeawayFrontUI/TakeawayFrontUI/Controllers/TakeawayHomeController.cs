using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SDK;

namespace TakeawayFrontUI.Controllers
{
    public class TakeawayHomeController : Controller
    {
        AreaBLL bll = new AreaBLL();
        // GET: TakeawayHome
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductHome()
        {
            return View();
        }

        /// <summary>
        /// 添加地址信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Address()
        {
            return View();
        }

        /// <summary>
        /// 菜品展示
        /// </summary>
        /// <returns></returns>
        public ActionResult showM()
        {
            return View();
        }
        [HttpPost]
        public JsonResult showM(ShowMenuInfoRequest showRequest)
        {
            ShowBll bll = new ShowBll();
            ShowMenuInfoResponse response = bll.Show(showRequest);
            return Json(response);
        }


        /// <summary>
        /// 404页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFind()
        {
            return View();
        }

        /// <summary>
        /// 用户信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfo()
        {
            return View();
        }

        /// <summary>
        /// 地址页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressView()
        {
            return View();
        }

        /// <summary>
        /// 修改地址页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EditAddress()
        {

            return View();
        }

        /// <summary>
        /// 确认订单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GenerateOrderView()
        {

            return View();
        }
    }
}
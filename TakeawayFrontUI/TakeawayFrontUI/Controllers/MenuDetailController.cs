using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDK;
using BLL;
namespace TakeawayFrontUI.Controllers
{
    public class MenuDetailController : Controller
    {
        MenuDetailBLL bll = new MenuDetailBLL();
        // GET: MenuDetail
        public ActionResult GetMenuDetail()
        {
            return View();
        }
        [HttpPost]
        public JsonResult MenuDteail(MenuDetailRequest request)
        {
            MenuDetailResponse response = bll.GetMenuDetati(request);
            return Json(response);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using log4net;
using SDK;
using Newtonsoft.Json;

namespace TakeawayFrontUI.Controllers
{
    public class UserController : Controller
    {
        UserBll userBll = new UserBll();
        // 登录页面
        public ActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// 用户注册
        /// </summary>

        public JsonResult AddUser(UserRequest userRequest)
        {
            return Json(userBll.AddUser(userRequest));
        }
        //登陆
        public JsonResult InfoResponse(DeLoginRequest Request)
        {
            return Json(userBll.InfoResponse(Request));
        }
        //找回密码
        public JsonResult FindPwd(ZhaopwdRequest request)
        {
            return Json(userBll.FindPwd(request));
        }
        //修改密码
        public JsonResult EditUserPwd(UpdateRequest request)
        {
            return Json(userBll.EditUserPwd(request));
        }
        //修改用户地址
        public JsonResult EditUserInfo(LocationRequest request)
        {
            return Json(userBll.EditUserInfo(request));
        }
        //显示地址信息
        public JsonResult ShowressInfo(ShowLocationRequest request)
        {
            ShowLocationResponse response = userBll.ShowressInfo(request);
            return Json(response);
        }

        //显示单条地址信息
        public JsonResult GetOneAddress(OneAddressRequest request)
        {
            OneAddressResponse response = userBll.GetOneAddress(request);
            return Json(response);
        }

        //添加新地址
        public JsonResult AddressInfo(AdLoctionRequest request)
        {
            return Json(userBll.AddressInfo(request));
        }
        /// <summary>
        /// 获取省份信息,用作绑定下拉框
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public JsonResult GetProvince(ProvinceRequest province)
        {
            return Json(userBll.GetProvince(province));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using log4net;
using SDK;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace TakeawayFrontUI.Controllers
{
    public class UserController : Controller
    {
        UserBll userBll = new UserBll();
        public ActionResult GeShow()
        {
            return View();
        }
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
        //验证码
        /// <summary>
        /// 生成简洁漂亮的图形验证码
        /// </summary>
        /// <param name="Code">传出验证码</param>
        /// <param name="CodeLength">验证码长度</param>
        /// <param name="Width">生成验证码图片的宽度</param>
        /// <param name="Height">生成验证码图片的高度</param>
        /// <param name="FontSize">验证码字符大小</param>
        /// <returns></returns>
        public static byte[] CreateValidateGraphic(out String Code, int CodeLength, int Width, int Height, int FontSize)
        {
            String sCode = String.Empty;
            //颜色列表，用于验证码、噪线、噪点
            Color[] oColors ={
             System.Drawing.Color.Black,
             System.Drawing.Color.Red,
             System.Drawing.Color.Blue,
             System.Drawing.Color.Green,
             System.Drawing.Color.Orange,
             System.Drawing.Color.Brown,
             System.Drawing.Color.Brown,
             System.Drawing.Color.DarkBlue
            };
            //字体列表，用于验证码
            string[] oFontNames = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            //验证码的字元集，去掉了一些容易混淆的字符
            char[] oCharacter = {
       '2','3','4','5','6','8','9',
       'A','B','C','D','E','F','G','H','J','K', 'L','M','N','P','R','S','T','W','X','Y'
      };
            Random oRnd = new Random();
            Bitmap oBmp = null;
            Graphics oGraphics = null;
            int N1 = 0;
            System.Drawing.Point oPoint1 = default(System.Drawing.Point);
            System.Drawing.Point oPoint2 = default(System.Drawing.Point);
            string sFontName = null;
            Font oFont = null;
            Color oColor = default(Color);
            //生成验证码字串
            for (N1 = 0; N1 <= CodeLength - 1; N1++)
            {
                sCode += oCharacter[oRnd.Next(oCharacter.Length)];
            }
            oBmp = new Bitmap(Width, Height);
            oGraphics = Graphics.FromImage(oBmp);
            oGraphics.Clear(System.Drawing.Color.White);
            try
            {
                for (N1 = 0; N1 <= 4; N1++)
                {
                    //画噪线
                    oPoint1.X = oRnd.Next(Width);
                    oPoint1.Y = oRnd.Next(Height);
                    oPoint2.X = oRnd.Next(Width);
                    oPoint2.Y = oRnd.Next(Height);
                    oColor = oColors[oRnd.Next(oColors.Length)];
                    oGraphics.DrawLine(new Pen(oColor), oPoint1, oPoint2);
                }
                float spaceWith = 0, dotX = 0, dotY = 0;
                if (CodeLength != 0)
                {
                    spaceWith = (Width - FontSize * CodeLength - 10) / CodeLength;
                }
                for (N1 = 0; N1 <= sCode.Length - 1; N1++)
                {
                    //画验证码字串
                    sFontName = oFontNames[oRnd.Next(oFontNames.Length)];
                    oFont = new Font(sFontName, FontSize, FontStyle.Italic);
                    oColor = oColors[oRnd.Next(oColors.Length)];
                    dotY = (Height - oFont.Height) / 2 + 2;//中心下移2像素
                    dotX = Convert.ToSingle(N1) * FontSize + (N1 + 1) * spaceWith;
                    oGraphics.DrawString(sCode[N1].ToString(), oFont, new SolidBrush(oColor), dotX, dotY);
                }
                for (int i = 0; i <= 30; i++)
                {
                    //画噪点
                    int x = oRnd.Next(oBmp.Width);
                    int y = oRnd.Next(oBmp.Height);
                    Color clr = oColors[oRnd.Next(oColors.Length)];
                    oBmp.SetPixel(x, y, clr);
                }
                Code = sCode;
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                oBmp.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                oGraphics.Dispose();
            }
        }

        /// <summary>
        /// 调用生成验证码方法
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImg()
        {
            int width = 100;
            int height = 40;
            int fontsize = 20;
            string code = string.Empty;
            byte[] bytes = CreateValidateGraphic(out code, 4, width, height, fontsize);
            Session["ValidateCode"] = code;
            return File(bytes, @"image/jpeg");
        }
        //登陆
        public JsonResult InfoResponse(DeLoginRequest Request)
        {
            DeLoginResponse response = userBll.InfoResponse(Request);
            if (response.userInfos.Id > 0)
            {
                Session["Id"] = response.userInfos.Id;
            }
            if (!string.IsNullOrEmpty(response.userInfos.PhoneNumber))
            {
                Session["PhoneNumber"] = response.userInfos.PhoneNumber;
            }


            return Json(response, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
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
        //显示订单 
        public JsonResult Dingshow(OrderGeRequest request)
        {
            return Json(userBll.Dingshow(request));
        }
    }
}
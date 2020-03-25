using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;
using SDK;

namespace Api.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfobll bll = new UserInfobll();
        //注册用户
        public int AddUser(UserInfo user)
        {
            return bll.AddUser(user);
        }
        //登陆
        public UserInfoResponse InfoResponse(UserRequest request)
        {
            return bll.InfoResponse(request);
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="PassWord"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public string FindPwd(string PhoneNumber, string PassWord, string Email)
        {
            string Content = "";
            string res = bll.FindPwd(PhoneNumber,PassWord,Email);

            if (!string.IsNullOrEmpty(res))
            {
                Content = "您好,您的密码为" + res;
                ForgetPwd(Email, Content);
            }
            else
            {
                Content = "您的账户出现问题,请重试";
                ForgetPwd(Email, Content);
            }

            return Content;

        }
        //邮箱
        public void ForgetPwd(string Email, string Content)
        {

        }
        ///修改密码
        public int EditUserPwd(string pwd, int id)
        {
            return bll.EditUserPwd(pwd,id);
        }
        //修改用户地址
        public int EditUserInfo(string content, int id)
        {
            return bll.EditUserInfo(content, id) ;
        }
        //显示地址信息
        public List<AddressInfo> ShowressInfo()
        {
            return bll.ShowressInfo();
        }
        //添加新地址
        public int AddressInfo(AddressInfo info)
        {
            return bll.AddressInfo(info);
        }
    }
}

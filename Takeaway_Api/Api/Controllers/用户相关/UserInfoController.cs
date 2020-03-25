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
        //注册用户
        public UserInfoResponse AddUser(UserRequest request)
        {
            return BaseBLL<UserInfobll>.Instance.AddUser(request);
        }
        //登陆
        public UserInfoResponse InfoResponse(UserRequest request)
        {
            return BaseBLL<UserInfobll>.Instance.InfoResponse(request);
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
            string res =BaseBLL<UserInfobll>.Instance.FindPwd(PhoneNumber,PassWord,Email);

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
        public UpdateResponse EditUserPwd(string pwd, int id)
        {
            UpdateResponse response = new UpdateResponse();
            response.User= BaseBLL<UserInfobll>.Instance.EditUserPwd(pwd,id);
            return response;
        }
        //修改用户地址
        public UserInfoResponse EditUserInfo(string content, int id)
        {
            UserInfoResponse response = new UserInfoResponse();
            response.User = BaseBLL<UserInfobll>.Instance.EditUserInfo(content,id);
            return response;
        }
        //显示地址信息
        public LocationResponse ShowressInfo(LocationRequest request)
        {
            LocationResponse response = new LocationResponse();
            response.User=Convert.ToInt32( BaseBLL<UserInfobll>.Instance.ShowressInfo());
            return response;
        }
        //添加新地址
        public AdLoctionResponse AddressInfo(AdLoctionRequest request,AddressInfo info)
        {
            AdLoctionResponse response = new AdLoctionResponse();
            response.User=Convert.ToInt32(BaseBLL<UserInfobll>.Instance.AddressInfo(info));
            return response;
             
        }
    }
}

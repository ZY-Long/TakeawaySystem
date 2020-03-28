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
        [HttpPost]
        public UserInfoResponse AddUser(UserRequest request)
        {
            UserInfoResponse response = new UserInfoResponse();
            response.User = BaseBLL<UserInfobll>.Instance.AddUser(request.User);
            response.State = true; return response;
            
        }
        //登陆
        [HttpPost]
        public DeLoginResponse InfoResponse(DeLoginRequest request)
        {
            DeLoginResponse user = BaseBLL<UserInfobll>.Instance.InfoResponse(request);
            user.State = true; return user;
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="PassWord"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpPost]
        public ZhaopwdResponse FindPwd(ZhaopwdRequest request)
        {
            ZhaopwdResponse response = new ZhaopwdResponse();
            string Content = "";
            string res = BaseBLL<UserInfobll>.Instance.FindPwd(request.PhoneNumber, request.PassWord, request.Email);

            if (!string.IsNullOrEmpty(res))
            {
                Content = "您好,您的密码为" + res;
                ForgetPwd(request.Email, Content);
            }
            else
            {
                Content = "您的账户出现问题,请重试";
                ForgetPwd(request.Email, Content);
            }
            response.State = true;
            return response;

        }
        //邮箱
        [HttpPost]
        public void ForgetPwd(string Email, string Content)
        {

        }
        //修改密码
        [HttpPost]
        public UpdateResponse EditUserPwd(UpdateRequest request)
        {
            UpdateResponse response = new UpdateResponse();
            response.User = BaseBLL<UserInfobll>.Instance.EditUserPwd(request.pwd, request.id);
            response.State = response.User > 0 ? true : false;
            return response;
        }
        //修改用户地址
        [HttpPost]
        public LocationResponse EditUserInfo(LocationRequest request)
        {
            LocationResponse response = new LocationResponse();
            response.UserId=BaseBLL<UserInfobll>.Instance.EditUserInfo(request.content, request.id);
            response.State = true; return response;
        }
        //显示地址信息
        [HttpPost]
        public ShowLocationResponse ShowressInfo(ShowLocationRequest request)
        {
            ShowLocationResponse response = new ShowLocationResponse();
            response.Infos = BaseBLL<UserInfobll>.Instance.ShowressInfo(request.UserId);
            response.State = true;
            return response;
        }

        //显示单条地址信息
        [HttpPost]
        public OneAddressResponse GetOneAddress(OneAddressRequest request)
        {
            OneAddressResponse response = new OneAddressResponse();
            //获取所有的地址信息
            List < UserAddress > infos= BaseBLL<UserInfobll>.Instance.ShowressInfo(request.UserId);
            response.Info = infos.Where(c => c.Id == request.AddressId).FirstOrDefault();
            response.State = true;
            return response;
        }

        //添加新地址
        [HttpPost]
        public AdLoctionResponse AddressInfo(AdLoctionRequest request, AddressInfo info)
        {
            AdLoctionResponse response = new AdLoctionResponse();
            response.User=Convert.ToInt32(BaseBLL<UserInfobll>.Instance.AddressInfo(info));
            response.State = true; return response;
             
        }
        [HttpPost]
        //显示订单 
        public OrderGeResponse Dingshow(OrderGeRequest request)
        {
            OrderGeResponse response = new OrderGeResponse();
            response.Uuers=BaseBLL<UserInfobll>.Instance.Dingshow(request.UserId);
            response.State = true;return response;
        }
    }
}

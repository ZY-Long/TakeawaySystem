﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace BLL
{
    public class UserBll
    {

        /// <summary>
        /// 注册用户
        /// </summary>
        public UserInfoResponse AddUser(UserRequest userRequest)
        {
            UserInfoResponse response = ApiRequestHelper.Post<UserRequest, UserInfoResponse>(userRequest);
            return response;
        }
        //登陆
        public DeLoginResponse InfoResponse(DeLoginRequest request)
        {
            DeLoginResponse response= ApiRequestHelper.Post<DeLoginRequest, DeLoginResponse>(request);
            return response;
        }
        //找回密码
        public ZhaopwdResponse FindPwd(ZhaopwdRequest request)
        {
            return ApiRequestHelper.Post<ZhaopwdRequest, ZhaopwdResponse>(request);
        }
        //修改密码
        public UpdateResponse EditUserPwd(UpdateRequest request)
        {
            return ApiRequestHelper.Post<UpdateRequest,UpdateResponse>(request);
        }
        //修改用户地址
        public LocationResponse EditUserInfo(LocationRequest request)
        {
            return ApiRequestHelper.Post<LocationRequest, LocationResponse>(request);
        }
        //显示地址信息
        public ShowLocationResponse ShowressInfo(ShowLocationRequest request)
        {
            ShowLocationResponse response= ApiRequestHelper.Post<ShowLocationRequest, ShowLocationResponse>(request);
            return response;
        }

        //显示单条地址信息
        public OneAddressResponse GetOneAddress(OneAddressRequest request)
        {
            OneAddressResponse response = ApiRequestHelper.Post<OneAddressRequest, OneAddressResponse>(request);
            return response;
        }
        //添加新地址
        public AdLoctionResponse AddressInfo(AdLoctionRequest request)
        {
            return ApiRequestHelper.Post<AdLoctionRequest, AdLoctionResponse>(request);
        }
        ///// <summary>
        ///// 获取用户
        ///// </summary>
        ///// <param name="request"></param>
        //public void GetUserInfo(UserGetRequest request)
        //{
        //    UserGetResponse response = new UserGetResponse();
        //    ApiRequestHelper.Post<UserGetRequest, UserGetResponse>(request);
        //}


        /// <summary>
        /// 获取省份信息,用作绑定下拉框
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        public ProvinceResponse GetProvince(ProvinceRequest province)
        {
            return ApiRequestHelper.Post<ProvinceRequest, ProvinceResponse>(province);
        }
        //显示订单 
        public OrderGeResponse Dingshow(OrderGeRequest request)
        {
            return ApiRequestHelper.Post<OrderGeRequest, OrderGeResponse>(request);
        }
        }
}

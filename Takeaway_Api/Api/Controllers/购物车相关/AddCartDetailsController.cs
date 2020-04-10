using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using SDK;
using Model;

namespace Api
{
    public class AddCartDetailsController : ApiController
    {
        [HttpPost]
        public AddCartDetailsResponse AddCartDetails(AddCartDetailsRequest request)
        {
            AddCartDetailsResponse response = new AddCartDetailsResponse();
            response.Add = BaseBLL<TakeBLL>.Instance.AddCartDetails(request.minefid, request.userId, request.count);
            response.State = true;
            return response;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public AddCartDetailsResponse CartTran(AddCartDetailsRequest request)
        {
            AddCartDetailsResponse response = new AddCartDetailsResponse();
            response.State = BaseBLL<TakeBLL>.Instance.CartTran(request.minefid, request.userId, request.count)>0?true:false;
            return response;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;
using SDK;

namespace Api
{
    /// <summary>
    /// 订单相关控制器
    /// </summary>
    public class OrderController : ApiController
    {
        /// <summary>
        /// 获取订单信息,用作显示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OrderResponse GetOrderShow(OrderRequest request)
        {
            OrderResponse response = new OrderResponse();
            response.Order = BaseBLL<OrderBLL>.Instance.GetOrderShow(request.UserId,request.BusinessId);
            return response;
        }
    }
}

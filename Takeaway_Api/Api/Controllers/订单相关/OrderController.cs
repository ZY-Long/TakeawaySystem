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
        [HttpPost]
        public OrderResponse GetOrderShow(OrderRequest request)
        {
            OrderResponse response = new OrderResponse();
            response.Order = BaseBLL<OrderBLL>.Instance.GetOrderShow(request.UserId, request.BusinessId);
            return response;
        }

        /// <summary>
        /// 生成订单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public GenerateOrderResponse GenerateOrder(GenerateOrderRequest request)
        {
            GenerateOrderResponse response = new GenerateOrderResponse();
            int res = BaseBLL<OrderBLL>.Instance.GenerateOrder(request.parameter);
            response.State = res > 0 ? true : false;
            return response;
        }

        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public GetOrdersResponse GetOrders(GetOrdersRequest request)
        {
            GetOrdersResponse response = new GetOrdersResponse();
            response.addresses = BaseBLL<OrderBLL>.Instance.GetOrders(request.Id);
            response.State = response.addresses.Count > 0 ? true : false;
            return response;
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public GetOrderDetailsResponse GetOrderDetails(GetOrderDetailsRequest request)
        {
            GetOrderDetailsResponse response = new GetOrderDetailsResponse();
            response.orders = BaseBLL<OrderBLL>.Instance.GetOrderDetails(request.UserId);

            response.State = response.orders.Count > 0 ? true : false;
            return response;
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public GenerateOrderResponse OrderTran(GenerateOrderRequest request)
        {
            GenerateOrderResponse response = new GenerateOrderResponse();
            response.State = BaseBLL<OrderBLL>.Instance.OrderTran(request.parameter) > 0 ? true : false;
            return response;
        }
    }
}

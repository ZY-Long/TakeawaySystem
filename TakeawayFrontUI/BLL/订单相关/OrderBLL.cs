using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace BLL
{
    /// <summary>
    /// 订单相关BLL
    /// </summary>
    public class OrderBLL
    {
        /// <summary>
        /// 获取订单信息,用作显示
        /// </summary>
        public OrderResponse GetOrderShow(OrderRequest request)
        {
            return ApiRequestHelper.Post<OrderRequest, OrderResponse>(request);
        }

        /// <summary>
        /// 生成订单信息
        /// </summary>
        public GenerateOrderResponse GenerateOrder(GenerateOrderRequest request)
        {
            return ApiRequestHelper.Post<GenerateOrderRequest, GenerateOrderResponse>(request);
        }

        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public GetOrdersResponse GetOrders(GetOrdersRequest request)
        {
            return ApiRequestHelper.Post<GetOrdersRequest, GetOrdersResponse>(request); 
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public GetOrderDetailsResponse GetOrderDetails(GetOrderDetailsRequest request)
        {
            return ApiRequestHelper.Post<GetOrderDetailsRequest, GetOrderDetailsResponse>(request);
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public GenerateOrderResponse OrderTran(GenerateOrderRequest request)
        {
            return ApiRequestHelper.Post<GenerateOrderRequest, GenerateOrderResponse>(request);
        }

        /// <summary>
        /// 获取订单的总价
        /// </summary>
        /// <returns></returns>
        public GetOrderPriceResponse GetOrderPrice(GetOrderPriceRequest request)
        {
            return ApiRequestHelper.Post<GetOrderPriceRequest, GetOrderPriceResponse>(request); 
        }
    }
}

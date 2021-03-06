﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

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
        /// <param name="UserId"></param>
        /// <param name="BusinessId"></param>
        /// <returns></returns>
        public OrderShow GetOrderShow(int UserId, int BusinessId)
        {
            return BaseDAL<OrderDAL>.Instance.GetOrderShow(UserId, BusinessId);

        }

        /// <summary>
        /// 生成订单信息
        /// </summary>
        /// <returns></returns>
        public int GenerateOrder(OrderParameter parameter)
        {
            return BaseDAL<OrderDAL>.Instance.GenerateOrder(parameter);
        }

        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OrderAddress> GetOrders(int UserId)
        {
            return BaseDAL<OrderDAL>.Instance.GetOrders(UserId);
        }


        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OderOrderDetailsShow> GetOrderDetails(int UserId)
        {
            return BaseDAL<OrderDAL>.Instance.GetOrderDetails(UserId);
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int OrderTran(OrderParameter order)
        {
            return BaseDAL<OrderDAL>.Instance.OrderTran(order);
        }

        /// <summary>
        /// 获取订单的总价
        /// </summary>
        /// <returns></returns>
        public decimal GetOrderPrice(string Ids)
        {
            return BaseDAL<OrderDAL>.Instance.GetOrderPrice(Ids);
        }
    }
}

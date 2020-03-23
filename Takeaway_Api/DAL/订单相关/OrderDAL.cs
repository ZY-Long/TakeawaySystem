using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    /// <summary>
    /// 订单信息相关DAL
    /// </summary>
    public class OrderDAL
    {
        /// <summary>
        /// 获取订单中的死信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BusinessId"></param>
        /// <returns></returns>
        public OrderShow GetOrderShow(int UserId, int BusinessId)
        {
            OrderShow order = OrmDBHelper.GetToList<OrderShow>(@"SELECT 
SUM(cd.ToPrice) AS TotalPrice,
c.Id,
u.NickName,
b.Name,
u.PhoneNumber,
b.PhoneNumber AS BusinessNumber,
b.Merchataddress
FROM dbo.CartInfo AS c
JOIN dbo.CartDetails AS cd
ON c.Id = cd.CartId
JOIN dbo.BusinessInfo AS b
ON b.Id = c.BusinessInfo
JOIN dbo.UserInfo AS u
ON c.UserId = u.Id
WHERE c.UserId = " + UserId + " AND c.BusinessInfo = " + BusinessId + " AND c.Sates = 1 GROUP BY b.Name, b.PhoneNumber, c.Id, u.NickName, u.PhoneNumber, b.Merchataddress").FirstOrDefault();
            order.list = GetListOrders(UserId, BusinessId);
            return order;

        }

        /// <summary>
        /// 查询出订单的list信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="BusinessId"></param>
        /// <returns></returns>
        public List<ListOrder> GetListOrders(int UserId, int BusinessId)
        {
            List<ListOrder> orders = OrmDBHelper.GetToList<ListOrder>(@"SELECT 
m.Name,
m.Img,
cd.ToPrice
FROM dbo.CartInfo AS c
JOIN dbo.CartDetails AS cd
ON c.Id=cd.CartId
JOIN dbo.BusinessInfo AS b
ON b.Id=c.BusinessInfo
JOIN dbo.UserInfo AS u
ON c.UserId=u.Id
JOIN dbo.MenuInfo AS m
ON m.Id=cd.DetailsId
WHERE c.UserId =" + UserId + " AND c.BusinessInfo=" + BusinessId + " AND c.Sates=1 ");
            return orders;
        }
    }
}

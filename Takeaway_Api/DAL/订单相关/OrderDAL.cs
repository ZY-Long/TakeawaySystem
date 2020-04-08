using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 订单信息相关DAL
    /// </summary>
    public class OrderDAL
    {
        int UserId = 0;
        int BusinessId = 0;

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

        /// <summary>
        /// 生成订单信息
        /// </summary>
        /// <returns></returns>
        public int GenerateOrder(OrderParameter parameter)
        {
            int res = 0;


            using (IDbConnection conn = new SqlConnection() { ConnectionString = "Data Source =.; Initial Catalog = TakeOutDB; Integrated Security = True" })
            {
                res = conn.Execute("GenerateOrder", parameter, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        /// <summary>
        /// 获取用户地址信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OrderAddress> GetOrders(int UserId)
        {
            string sql = @"SELECT ad.Id,ad.Content,ae.Name FROM dbo.AddressInfo AS ad
JOIN dbo.Arealnfo AS ae
ON ad.Area=ae.Id
WHERE UserId=" + UserId + " AND Sates=1";

            List<OrderAddress> orders = OrmDBHelper.GetToList<OrderAddress>(sql);
            return orders;
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OderOrderDetailsShow> GetOrderDetails(int UserId)
        {
            string sql = @"SELECT m.Img,m.Name,m.Price,od.Count,od.CreateTime FROM dbo.OrderDetails AS od
    JOIN dbo.MenuInfo AS m
    ON od.DetailsId = m.Id
     WHERE OrderId IN(SELECT o.Id FROM dbo.UserInfo AS u JOIN dbo.OrderInfo AS o ON u.Id = o.UserId WHERE u.Id ="+UserId+" AND o.[Sates] = 1)AND Od.Sates = 1";
            List<OderOrderDetailsShow> orders = OrmDBHelper.GetToList<OderOrderDetailsShow>(sql);
            
            return orders;
        }
       

    }
}

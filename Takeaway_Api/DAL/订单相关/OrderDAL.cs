using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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
     WHERE OrderId IN(SELECT o.Id FROM dbo.UserInfo AS u JOIN dbo.OrderInfo AS o ON u.Id = o.UserId WHERE u.Id =" + UserId + " AND o.[Sates] = 1)AND Od.Sates = 1";
            List<OderOrderDetailsShow> orders = OrmDBHelper.GetToList<OderOrderDetailsShow>(sql);

            return orders;
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        /// <returns></returns>
        public int OrderTran(OrderParameter order)
        {
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]))
            {
                conn.Open();
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    //添加购物车信息
                    StringBuilder sql = new StringBuilder(@"INSERT  dbo.OrderInfo
        ( UserId ,
          AddressId ,
          DataState ,
          Freight ,
          PackagingFee ,
          TablewareCount ,
          ActivityId ,
          TotalPrice ,
          Consignee ,
          BusinessInfo ,
          Sates ,
          CreateTime ,
          UpdateTime ,
          CreaterId ,
          UpdaterId
        )
VALUES  ( "+order.UserId+","+order.AddressId+",1,10,2,0,0,"+order.TotalPrice+",'"+order.Consignee+"',"+order.AddressId+",1,GETDATE(),GETDATE(),1,1)");
                    conn.Execute(sql.ToString(),null,transaction);

                    //找到新添加的订单Id
                    StringBuilder sql1 = new StringBuilder("SELECT MAX(Id) FROM dbo.OrderInfo WHERE UserId="+order.UserId+" AND [Sates]=1");
                    int OrderId = Convert.ToInt32(conn.ExecuteScalar(sql1.ToString(),null,transaction));

                    //找到购物车表中要生成订单的数据
                    order.Ids = order.Ids.Replace('"',' ');
                    order.Ids = order.Ids.Replace('[', ' ');
                    order.Ids = order.Ids.Replace(']', ' ');
                    StringBuilder sql2 = new StringBuilder(@"SELECT cd.TasteId,cd.TypeId,cd.DetailsId,cd.Count FROM dbo.CartInfo AS c
JOIN dbo.CartDetails AS cd
ON c.Id=cd.CartId
WHERE c.UserId="+order.UserId+" AND cd.Id IN("+order.Ids+") AND cd.Sates=1");
                    List<OrderList> lists = conn.Query<OrderList>(sql2.ToString(), null, transaction).ToList() ;

                    //将购物车表中的数据添加到订单详情表
                    foreach (var item in lists)
                    {
                        StringBuilder sql3 = new StringBuilder(@"    INSERT dbo.OrderDetails
            ( OrderId ,
              TypeId ,
              DetailsId ,
              Count ,
              TasteId ,
              Content ,
              Sates ,
              CreateTime ,
              UpdateTime ,
              CreaterId ,
              UpdaterId
            )
    VALUES  ( "+OrderId+","+item.TypeId+","+item.DetailsId+","+item.Count+","+item.TeasteId+",'"+order.Content+"',1,GETDATE(),GETDATE(),1,1)");
                        conn.Execute(sql3.ToString(), null, transaction);
                    }

                    //添加成功后,将购物车表中的数据删除
                    StringBuilder sql4 = new StringBuilder("UPDATE dbo.CartDetails SET Sates=-1  where Id IN(" + order.Ids+")");
                    conn.Execute(sql4.ToString(), null, transaction);

                    
                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string msg = ex.Message;
                    return 0;
                    throw;
                }
            }
        }
    }
}

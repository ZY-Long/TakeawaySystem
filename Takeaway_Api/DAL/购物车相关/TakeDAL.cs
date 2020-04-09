using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using SDK;
using System.Data;
using System.Configuration;
using Dapper;

namespace DAL
{
    /// <summary>
    /// 外卖数据访问层
    /// </summary>
    public class TakeDAL
    {
        readonly static string connstr = System.Configuration.ConfigurationManager.AppSettings["conn"];
        SqlConnection connection = new SqlConnection(connstr);
        /// <summary>
        /// 清空购物车
        /// 1.用户点击清空购物车获取所有页面上信息Id
        /// 2.用一个List<int>存储这个获取到的Id
        /// 3.foreach嵌套访问数据库语句


        /// <summary>
        /// 添加购物车详情
        /// </summary>
        public int AddCartDetails(int minefid, int userId, int count)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = "AddCart";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(new SqlParameter[]
                {
                new SqlParameter{ParameterName = "@minefid",SqlDbType = System.Data.SqlDbType.Int,SqlValue = minefid },
                 new SqlParameter{ParameterName = "@userId",SqlDbType = System.Data.SqlDbType.Int,SqlValue = userId },
                 new SqlParameter{ParameterName = "@count",SqlDbType = System.Data.SqlDbType.Int,SqlValue = count },
                });
                int res = command.ExecuteNonQuery();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return 0;
            }

        }
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCart(int id)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "Update CartDetails set Sates=-1 where Id =" + id;
            SqlCommand command = new SqlCommand(sql, connection);
            var res = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            return res;
        }
        /// <summary>
        /// 显示购物车
        /// </summary>
        /// <returns></returns>
        public List<CartInfos> GetCartInfos(int userid)
        {
            try
            {

                string sql = $@"select c.Id,  m.Img,m.Name,m.Price,c.Count,c.ToPrice from CartDetails as c
                        join CartInfo as a on c.CartId=a.Id
                        join MenuInfo as m on c.DetailsId =m.Id where c.[Sates]=1 and a.UserId={userid} order by c.Id desc";

                List<CartInfos> infos = OrmDBHelper.GetToList<CartInfos>(sql);

                return infos;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                throw;
            }

        }
        /// <summary>
        /// 显示商品详情商品详情
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public MenuDetail GetMenuDetail(int menuid)
        {

            string sql = $@"select * from [dbo].[MenuInfo] as m where m.Id=" + menuid;
            List<MenuDetail> infos = OrmDBHelper.GetToList<MenuDetail>(sql);
            MenuDetail menu = infos.FirstOrDefault();
            return menu;
        }
        /// <summary>
        /// 口味下拉框
        /// </summary>
        /// <returns></returns>
        public List<TasteInfo> GetTakeInfos()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "Select Name from TasteInfo";
            SqlCommand command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            var list = reader.DataReaderToList<TasteInfo>();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            return list;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        public int CartTran(int minefid, int userId, int count)
        {
            using (IDbConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]))
            {
                conn.Open();
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    //--判断是否存在购物车
                    StringBuilder sql1 = new StringBuilder(" select  max(ca.Id) from  CartInfo as ca where ca.UserId=" + userId + " and ca.Sates=1;");
                    int CartId = Convert.ToInt32(conn.ExecuteScalar(sql1.ToString(), null, transaction));

                    //找到商品的typeId
                    StringBuilder sql5 = new StringBuilder("select  TypeId from [dbo].[MenuInfo] where id=" + minefid + " and [Sates]=1");
                    int typeId = Convert.ToInt32(conn.ExecuteScalar(sql5.ToString(), null, transaction));

                    //找到商品的价格
                    StringBuilder sql6 = new StringBuilder("select  Price from [dbo].[MenuInfo] where id=" + minefid + " and [Sates]=1");
                    decimal price = Convert.ToDecimal(conn.ExecuteScalar(sql6.ToString(), null, transaction));

                    //如果存在购物车
                    if (CartId > 0)
                    {
                        //--判断是否存在这件商品
                        StringBuilder sql2 = new StringBuilder("select count(*) from  [dbo].[CartDetails] as c join [dbo].[CartInfo] as ca on c.[CartId]=ca.Id where ca.UserId=" + userId + " and ca.Sates=1 and  c.[DetailsId]=" + minefid + " AND c.CartId=" + CartId + " AND c.Sates=1");
                        int ProcId = Convert.ToInt32(conn.ExecuteScalar(sql2.ToString(), null, transaction));

                        //获取这件商品的购物车详情Id
                        StringBuilder sql3 = new StringBuilder("select Id from  dbo.CartDetails as ca where ca.DetailsId=" + minefid + " and ca.Sates=1 AND CartId=" + CartId + "");
                        int CartContentId = Convert.ToInt32(conn.ExecuteScalar(sql3.ToString(), null, transaction));


                        //如果存在这件商品
                        if (ProcId > 0)
                        {

                            //让这件商品的数量+1
                            StringBuilder sql4 = new StringBuilder("Update [dbo].[CartDetails] set [Count]=[Count]+1 where [CartId]="+CartId+" and [DetailsId]="+minefid+" and [Sates]=1 AND Id="+CartContentId+"");
                            conn.Execute(sql4.ToString(), null, transaction);
                        }
                        //如果不存在这件商品
                        else
                        {


                            //添加这件商品
                            StringBuilder sql4 = new StringBuilder(@"INSERT dbo.CartDetails
         (TypeId,
           DetailsId,
           Count,
           TasteId,
           ToPrice,
           CartId,
           Sates,
           CreateTime,
           UpdateTime,
           CreaterId,
           UpdaterId
         )
 VALUES("+typeId+","+minefid+ ","+count+", 0,"+price+", "+ CartId + ",1,GETDATE(),GETDATE(),1,1)");
                            conn.Execute(sql4.ToString(), null, transaction);

                        }

                    }
                    //如果不存在购物车
                    else
                    {
                        //添加购物车
                        StringBuilder sql4 = new StringBuilder(@"	  		 INSERT  dbo.CartInfo
		         ( UserId ,
		           BusinessInfo ,
		           Sates ,
		           CreateTime ,
		           UpdateTime ,
		           CreaterId ,
		           UpdaterId
		         )
		 VALUES  ( "+userId+" , 1 , 1 , GETDATE() ,GETDATE() ,1 ,1  )");
                        conn.Execute(sql4.ToString(), null, transaction);

                        //获取刚刚添加的购物车的Id
                        StringBuilder sql7 = new StringBuilder("select  MAX(Id) from  CartInfo as ca where ca.UserId="+userId+" and ca.Sates=1;");
                        int cartId = Convert.ToInt32(conn.ExecuteScalar(sql5.ToString(), null, transaction));

                        //添加购物车详情表
                        StringBuilder sql8 = new StringBuilder(@"		 INSERT dbo.CartDetails
         ( TypeId ,
           DetailsId ,
           Count ,
           TasteId ,
           ToPrice ,
           CartId ,
           Sates ,
           CreateTime ,
           UpdateTime ,
           CreaterId ,
           UpdaterId
         )
 VALUES  ( "+typeId+" , "+minefid+" , "+count+" ,0 , "+price+" ,"+cartId+" ,1 ,GETDATE() ,GETDATE() , 1 , 1)");
                        conn.Execute(sql4.ToString(), null, transaction);
                    }


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

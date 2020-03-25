using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
namespace DAL
{
    /// <summary>
    /// 外卖数据访问层
    /// </summary>
    public class TakeDAL
    {
        SqlConnection connection = new SqlConnection("Data Source=.\\sql2014;Initial Catalog=TakeOutDB;Integrated Security=True");
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
            var res = command.ExecuteNonQuery();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            return res;
        }
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCart(int id)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "Update CartDetails set Sates=-1 where Id ="+id;
            SqlCommand command = new SqlCommand(sql,connection);
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
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            string sql = $@"select c.Id,  m.Img,m.Name,m.Price,c.Count,c.ToPrice from CartDetails as c
                        join CartInfo as a on c.CartId=a.Id
                        join MenuInfo as m on c.DetailsId =m.Id where c.[Sates]=1 and a.UserId={userid} order by c.Id desc";
            SqlCommand command = new SqlCommand(sql,connection);
            var reader = command.ExecuteReader();
            var list = reader.DataReaderToList<CartInfos>();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            return list;
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
        
        
    }
}

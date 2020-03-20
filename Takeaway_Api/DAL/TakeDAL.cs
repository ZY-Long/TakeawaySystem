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
        SqlConnection connection = new SqlConnection("Data Source=.\\sql2014;Initial Catalog=TakeawayDb;Integrated Security=True");

        public int AddCart(CartInfo cart)
        {
            connection.Open();
            string sql = $@"insert into CartInfo (UserId,BusinessInfo) values('{cart.UserId}','{cart.BusinessInfo}')";
            SqlCommand command = new SqlCommand(sql,connection);
            var res = command.ExecuteNonQuery();
            return res;
        }
        public int AddCartDetails(CartDetails cart)
        {
            connection.Open();
            string sql = $@"insert into CartDetails (TypeId,DetailsId,Count,TasteId,ToPrice) values('{cart.TypeId}','{cart.DetailsId}','{cart.Count}','{cart.TasteId}','{cart.ToPrice}')";
            SqlCommand command = new SqlCommand(sql, connection);
            var res = command.ExecuteNonQuery();
            return res;
        }
    }
}

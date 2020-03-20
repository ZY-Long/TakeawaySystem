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
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int AddCart(CartInfo cart)
        {
            connection.Open();
            string sql = $@"insert into CartInfo (UserId,BusinessInfo) values('{cart.UserId}','{cart.BusinessInfo}')";
            SqlCommand command = new SqlCommand(sql,connection);
            var res = command.ExecuteNonQuery();
            return res;
        }
        /// <summary>
        /// 添加购物车详情
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int AddCartDetails(CartDetails cart)
        {
            connection.Open();
            string sql = $@"insert into CartDetails (TypeId,DetailsId,Count,TasteId,ToPrice) values('{cart.TypeId}','{cart.DetailsId}','{cart.Count}','{cart.TasteId}','{cart.ToPrice}')";
            SqlCommand command = new SqlCommand(sql, connection);
            var res = command.ExecuteNonQuery();
            return res;
        }
        /// <summary>
        /// 显示购物车
        /// </summary>
        /// <returns></returns>
        public List<CartDetails> ShowCartDetails()
        {
            connection.Open();
            string sql = @"select m.Name,m.Img,m.Price,d.Name,d.Img,d.Price,t.Name,p.Name,p.Img,p.Price from CartDetails as c
                        join MenuInfo as m on c.Id=m.TypeId
                        join DrinkInfo as d on c.Id=d.TypeId
                        join TasteInfo as t on t.Id=c.TasteId
                        join PackageInfo as p on p.TypeId=c.Id";
            SqlCommand command = new SqlCommand(sql,connection);
            var reader = command.ExecuteReader();
            var list = reader.DataReaderToList<CartDetails>();
            return list;
        }
        /// <summary>
        /// 口味下拉框
        /// </summary>
        /// <returns></returns>
        public List<TasteInfo> ShowTasteInfo()
        {
            connection.Open();
            string sql = "Select Name from TasteInfo";
            SqlCommand command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            var list = reader.DataReaderToList<TasteInfo>();
            return list;
        }
    }
}

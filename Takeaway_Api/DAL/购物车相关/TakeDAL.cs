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
        /// 添加购物车
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int AddCart(CartInfo cart)
        {
            connection.Open();
            string sql = $@"insert into CartInfo (UserId,BusinessInfo,Sates,CreateTime,UpdateTime,CreaterId,UpdaterId) 
                    values('{cart.UserId}','{cart.BusinessInfo}',1,'GetDate()','GetDate()',1,1)";
            SqlCommand command = new SqlCommand(sql, connection);
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
            CartInfo c = new CartInfo();

            var car = AddCart(c);
            connection.Open();
            string sql = $@"insert into CartDetails (TypeId,DetailsId,Count,TasteId,ToPrice,CartId,Sates,CreateTime,UpdateTime,CreaterId,UpdaterId) 
                    values('{cart.TypeId}','{cart.DetailsId}','{cart.Count}','{cart.TasteId}','{cart.ToPrice}','{cart.CratId}',1,'GetDate()','GetDate()',1,1)";
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
            string sql = @"select m.Name,m.Img,m.Price from CartDetails as c
                        join CartInfo as a on c.CartId=a.Id
                        join MenuInfo as m on c.TypeId =m.Id";
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

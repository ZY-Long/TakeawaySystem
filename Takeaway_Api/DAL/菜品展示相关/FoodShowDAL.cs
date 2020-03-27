using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using Model;

namespace DAL
{
    public class FoodShowDAL
    {

        readonly static string connstr = System.Configuration.ConfigurationManager.AppSettings["conn"];

        SqlConnection conn = new SqlConnection(connstr);
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="currPage">当前页码</param>
        /// <param name="Name">菜品名</param>
        /// <param name="TypeId">菜品类型</param>
        /// <returns></returns>
        public List<MenuInfo> Show(int currPage,  int TypeId, string Name = "")
        {
            try
            {
                //打开数据库
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                //命令
                string sql = "prcPageResult";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddRange(new SqlParameter[]
                {
                new SqlParameter{ParameterName = "@currPage",SqlDbType = System.Data.SqlDbType.Int,SqlValue = currPage },
                 new SqlParameter{ParameterName = "@Name",SqlDbType = System.Data.SqlDbType.VarChar,SqlValue = Name },
                 new SqlParameter{ParameterName = "@TypeId",SqlDbType = System.Data.SqlDbType.Int,SqlValue = TypeId },
                });

                //反馈
                var readr = comm.ExecuteReader();

                List<MenuInfo> list = new List<MenuInfo>();
                while (readr.Read())
                {
                    MenuInfo menuInfo = new MenuInfo();
                    menuInfo.Id = int.Parse(readr["Id"].ToString());
                    menuInfo.Name = readr["Name"].ToString();
                    menuInfo.Img = readr["Img"].ToString();
                    menuInfo.Price = Convert.ToDecimal(readr["Price"]);
                    list.Add(menuInfo);
                }

                //关闭数据库
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }

           
        }
    }
}

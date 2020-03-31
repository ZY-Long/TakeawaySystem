using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace DAL
{
    public class FoodShowDAL
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=TakeOutDB;Integrated Security=True");
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="currPage">当前页码</param>
        /// <param name="Name">菜品名</param>
        /// <param name="TypeId">菜品类型</param>
        /// <returns></returns>
        public show Show(int currPage,  int TypeId, string Name = null)
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
            show show = new show();
            while (readr.Read())
            {
                
                show.currPage =int.Parse( readr["currPage"].ToString());
                show.Name = readr["currPage"].ToString();
                show.TypeId = int.Parse(readr["TypeId"].ToString());
            }

            //关闭数据库
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            
            return show;
        }
    }
}

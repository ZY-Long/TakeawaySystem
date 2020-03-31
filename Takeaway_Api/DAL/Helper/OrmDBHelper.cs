using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{

    public class OrmDBHelper
    {
        readonly static string conn = System.Configuration.ConfigurationManager.AppSettings["conn"];
        private  static string connectionString = conn;

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static List<T> GetToList<T>(string sql) where T : class, new()
        {
            List<T> list = new List<T>();
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                list = conn.Query<T>(sql).ToList();
            }
            return list;
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <typeparam name="T">类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static T GetModel<T>(string sql) where T : class, new()
        {
            T model = new T();
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                model = conn.QueryFirstOrDefault<T>(sql);
            }
            return model;
        }

        /// <summary>
        /// 增删改 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            int res = 0;
            using (IDbConnection conn = new SqlConnection() { ConnectionString = connectionString })
            {
                res = conn.Execute(sql);
            }
            return res;
        }
    }
}

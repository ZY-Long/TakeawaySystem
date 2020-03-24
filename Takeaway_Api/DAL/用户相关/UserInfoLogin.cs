﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DAL
{
    //用户相关DAL
  public  class UserInfoLogin
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TakeOutDB;Integrated Security=True");
        DBHelper bHelper = new DBHelper();
        string connStr = "Data Source=.;Initial Catalog=TakeOutDB;Integrated Security=True";

        //用户注册
        public int AddUser(UserInfo user)
        {
            connection.Open();
            var bus = UserInfoLogin.GenerateSalt();
            string sql = $@"insert into UserInfo(NickName,Img,PhoneNumber,Password,Salt,Email,RealName,CreateTime,UpdateTime,CreaterId,UpdaterId) 
                                 values('{user.NickName}','{user.PhoneNumber}','{MD5Encrypt32(user.PassWord + "{"+bus+"}")}','{bus}','{user.Email}','{user.RealName},'{user.CreateTime}','{user.UpdateTime}','{user.CreaterId}','{user.UpdaterId}'')";
            SqlCommand command = new SqlCommand(sql,connection);
            var res = command.ExecuteNonQuery();
            return res;
        }
        /// <summary>
        /// 生成盐
        /// 此处生成4位的盐
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            string salt = string.Empty;
            //字母
            List<string> list = new List<string>()
            {
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
            };
            var seed = new Random().Next();
            for (int i = 0; i < 4; i++)
            {
                salt += list[new Random(seed * i).Next(0, list.Count - 1)];
            }

            return salt;
        }
        //用户登陆
        public int DeLogin(UserInfo info)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "select count(1) from UserInfo where PhoneNumber=@phonenumber and Password=@password";
                var userId = conn.QueryFirstOrDefault<int>(sql,new { phonenumber=info.PhoneNumber,password=info.PassWord});
                return userId;
            }
        }
        //public int DeLogin(UserInfo info)
        //{

        //    var res = UserInfoLogin.GenerateSalt();
        //    string sql =string.Format("select count(1) from UserInfo where PhoneNumber='{0}' and Password='{1}'",info.PhoneNumber, MD5Encrypt32(info.PassWord+"{"+res+"}"));          
           
        //    return Convert.ToInt32(bHelper.ExecuteScalar(sql));
        //}
        //根据用户名获取用户的盐
        public string GetuserSalt(string UserName)
        {
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                string sql = "select Salt From UserInfo where PhoneNumber=@phonenumber";
                var saltstr = conn.QueryFirstOrDefault<string>(sql,new { phonenumber=UserName});
                return saltstr;
            }
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string Password)
        {
            string cl = Password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        ///修改密码
        ///
        public int EditUserPwd(string pwd,int id)
        {
            int res = 0;
            res = bHelper.ExecuteNonQuery("update UserInfo set Password='"+pwd+"' where Id='"+id+"'");
            return res;
        }
        //修改用户地址
        public int EditUserInfo(string content,int id)
        {
            int res = 0;
            res = bHelper.ExecuteNonQuery("update AddressInfo set Content='" + content + "' where Id in(select UserId=Id from UserInfo where Id='" + id + "')");
            return res;
        }
        //显示地址信息
        public List<AddressInfo> ShowressInfo()
        {
            List<AddressInfo> infos = new List<AddressInfo>();
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                infos = conn.Query<AddressInfo>("select * from AddressInfo").ToList();
            }
            return infos;
        }
        //添加新地址
        //public int AddressInfo(AddressInfo info)
        //{
        //    connection.Open();
        //    string sql = @"insert into AddressInfo values('{0}','{1}','{2}')";
        //}

    }
}

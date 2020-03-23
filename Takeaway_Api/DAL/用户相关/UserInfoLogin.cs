using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    //用户相关DAL
  public  class UserInfoLogin
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TakeOutDB;Integrated Security=True");
        DBHelper bHelper = new DBHelper();
        //用户注册
        public int AddUser(UserInfo user)
        {
            connection.Open();
            string sql = $@"insert into UserInfo(NickName,Img,PhoneNumber,Password,Salt,Email,RealName,CreateTime,UpdateTime,CreaterId,UpdaterId) 
                                 values('{user.NickName}','{user.PhoneNumber}','{user.PassWord}','{user.Salt}','{user.Email}','{user.RealName},'{user.CreateTime}','{user.UpdateTime}','{user.CreaterId}','{user.UpdaterId}'')";
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
            string sql =string.Format("select count(1) from UserInfo where PhoneNumber='{0}' and Password='{1}'",info.PhoneNumber, MD5Encrypt32(info.PassWord));          
            return Convert.ToInt32(bHelper.ExecuteScalar(sql));
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
    }
}

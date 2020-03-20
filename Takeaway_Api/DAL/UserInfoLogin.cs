using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    //用户相关DAL
  public  class UserInfoLogin
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TakeawayDb;Integrated Security=True");
      
        //用户注册
        public int AddUser(UserInfo user)
        {
            connection.Open();
            string sql = $@"insert into UserInfo(NickName,Img,PhoneNumber,Password,Salt,Email,MyProperty) values('{user.NickName}','{user.PhoneNumber}','{user.PassWord}','{user.Salt}','{user.Email}','{user.MyProperty}')";
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

    }
}

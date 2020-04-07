using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;
using SDK;

namespace DAL
{
    //用户相关DAL
    public class UserInfoLogin
    {
        readonly static string connstr = System.Configuration.ConfigurationManager.AppSettings["conn"];
        SqlConnection connection = new SqlConnection(connstr);


        DBHelper bHelper = new DBHelper();
        string connStr = connstr;

        //用户注册
        public int AddUser(UserInfo user)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var bus = UserInfoLogin.GenerateSalt();
                string sql = $@"insert into UserInfo(NickName,Img,PhoneNumber,Password,Salt,Email,RealName,CreateTime,UpdateTime,CreaterId,UpdaterId) 
                                 values('{user.NickName}','','{user.PhoneNumber}','{MD5Encrypt32(user.PassWord + bus)}','{bus}','{user.Email}','{user.RealName}','{DateTime.Now}','{DateTime.Now}','{user.CreaterId}','{user.UpdaterId}')";
                SqlCommand command = new SqlCommand(sql, connection);
                var res = command.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 生成盐
        /// 此处生成4位的盐
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        //用户登陆
        public UserInfoDto DeLogin(UserInfoLog info)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connStr))
                {
                    string sql = "select PhoneNumber ,Id from UserInfo where PhoneNumber=@phonenumber and Password=@password";
                    var userLog = conn.QueryFirstOrDefault<UserInfoDto>(sql, new { phonenumber = info.PhoneNumber, password = info.PassWord });
                    return userLog;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public int DeLogin(UserInfo info)
        //{

        //    var res = UserInfoLogin.GenerateSalt();
        //    string sql =string.Format("select count(1) from UserInfo where PhoneNumber='{0}' and Password='{1}'",info.PhoneNumber, MD5Encrypt32(info.PassWord+"{"+res+"}"));          

        //    return Convert.ToInt32(bHelper.ExecuteScalar(sql));
        //}
        //根据用户名获取用户的盐
        public string GetuserSalt(string PhoneNumber)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connStr))
                {
                    string sql = "select Salt From UserInfo where PhoneNumber=@phonenumber";
                    var saltstr = conn.QueryFirstOrDefault<string>(sql, new { phonenumber = PhoneNumber });
                    return saltstr;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string Password)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="PassWord"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public string FindPwd(string PhoneNumber, string PassWord, string Email)
        {
            try { 
            UserInfo info = OrmDBHelper.GetModel<UserInfo>("select PassWord from UserInfo where PhoneNumber='" + PhoneNumber + "' and PassWord='" + PassWord + "'");
            string res = "";
            if (info != null)
            {
                res = info.PassWord;
            }
            return res;
        }
              catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="EmailUrl"></param>
        /// <returns></returns>
        public void ForgetPwd(string Email, string Content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mail.From = new MailAddress("zyl3086362103@163.com");
                mail.To.Add(new MailAddress(Email));

                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Subject = "找回密码";
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                mail.Body = Content;

                //发件邮箱的服务器地址
                smtp.Host = "smtp.163.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 10000;
                //是否为SSL加密
                smtp.EnableSsl = true;
                //设置端口,如果不设置的话,默认端口为25,QQ邮箱587 465 Or 百度
                smtp.Port = 25;
                smtp.UseDefaultCredentials = true;
                //验证发件人的凭据
                smtp.Credentials = new System.Net.NetworkCredential("zyl3086362103@163.com", "z118114");

                try
                {
                    //发送邮件
                    smtp.Send(mail);
                }
                catch (Exception e1)
                {

                }
            }
           catch (Exception)
            {
                throw;
            }
        }
        


        ///修改密码
        public int EditUserPwd(string pwd, int id)
        {
            try
            {
                var bus = UserInfoLogin.GenerateSalt();
                int res = 0;
                res = bHelper.ExecuteNonQuery("update UserInfo set Password='" + MD5Encrypt32(pwd + bus) + "' and Salt=" + bus + " where Id='" + id + "'");
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //修改用户地址
        public int EditUserInfo(string content, int Areaid, int UserId, int Id)
        {
            try
            {
                int res = 0;
                string sql = "UPDATE dbo.AddressInfo SET Content='" + content + "' ,Area=" + Areaid + " WHERE UserId=" + UserId + " AND Id=" + Id + "";
                res = bHelper.ExecuteNonQuery(sql);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //显示地址信息
        public List<UserAddress> ShowressInfo(int UserId)
        {
            try
            {
                List<UserAddress> infos = new List<UserAddress>();
                using (IDbConnection conn = new SqlConnection(connStr))
                {
                    infos = conn.Query<UserAddress>("SELECT a.Id,aa.Name,a.Content FROM dbo.AddressInfo AS a JOIN dbo.Arealnfo AS aa ON a.Area = aa.Id WHERE a.UserId = " + UserId + "  AND a.Sates=1").ToList();
                }
                return infos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //添加新地址
        public int AddressInfo(AddressInfo info)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string sql = $@"insert into AddressInfo(ProvinceId,CityId,Area,UserId,Content,Sates,CreateTime,UpdateTime,CreaterId,UpdaterId)
            values(1,1,'{info.AreaId}','{info.UserId}','{info.Content}',1,GETDATE(),GETDATE(),1,1)";
                SqlCommand command = new SqlCommand(sql, connection);
                var res = command.ExecuteNonQuery();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }



        //显示订单 
        public List<UserInfo> Dingshow(int UserId)
        {
            try
            {
                List<UserInfo> infos = new List<UserInfo>();
                using (IDbConnection conn = new SqlConnection(connStr))
                {
                    infos = conn.Query<UserInfo>("select m.Img,m.Name,cd.ToPrice,cd.Count, cd.CreateTime FROM dbo.CartInfo AS c JOIN dbo.CartDetails AS cd ON c.Id = cd.CartId JOIN dbo.BusinessInfo AS b ON b.Id = c.BusinessInfo JOIN dbo.UserInfo AS u ON c.UserId = u.Id JOIN dbo.MenuInfo AS m ON m.Id = cd.DetailsId WHERE c.UserId =" + UserId + " ").ToList();
                }
                return infos;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}




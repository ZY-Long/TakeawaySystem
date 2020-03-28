using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using SDK;
using System.Security.Cryptography; 


namespace BLL
{
   
   public  class UserInfobll
    {
        UserInfoLogin dal = new UserInfoLogin();

        public int AddUser(UserInfo user)
        {
            return BaseDAL<UserInfoLogin>.Instance.AddUser(user);
        }


        ////用户登陆
        //public int DeLogin(UserInfo info)
        //{
        //    return BaseDAL<UserInfoLogin>.Instance.DeLogin(info);
        //}
        public DeLoginResponse InfoResponse(DeLoginRequest request)
        {
            DeLoginResponse userInfo = new DeLoginResponse();
            string salt = dal.GetuserSalt(request.User.PhoneNumber);
            string password = MD5Encrypt32(request.User.PassWord+salt);
            request.User.PassWord = password;
            if (string.IsNullOrEmpty(request.User.PhoneNumber))
            {
                userInfo.State = false;
                userInfo.Message = "用户名为空";
                return userInfo;
            }
            if (string.IsNullOrEmpty(request.User.PassWord))
            {
                userInfo.State = false;
                userInfo.Message = "密码为空";
                return userInfo;
            }
            //调用dal层方法
            int userid = dal.DeLogin(request.User);
            //判断
            if (userid>0)
            {
                userInfo.State = true;
                userInfo.Message="登陆成功 ！";
            }
            else
            {
                userInfo.State = false;
                userInfo.Message = "登陆失败，密码错误 ！";
            }
            return userInfo;
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
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="PassWord"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public string FindPwd(string PhoneNumber, string PassWord,string Email)
        {
            return dal.FindPwd(PhoneNumber,PassWord,Email);
        }
        //邮箱
        public void ForgetPwd(string Email, string Content)
        {
            
        }
            ///修改密码
            ///
            public int EditUserPwd(string pwd, int id)
        {
            return BaseDAL<UserInfoLogin>.Instance.EditUserPwd(pwd,id);
        }
        //修改用户地址
        public int EditUserInfo(string content, int Areaid, int UserId, int Id)
        {
            return BaseDAL<UserInfoLogin>.Instance.EditUserInfo(content,Areaid,UserId,Id);
        }
        //显示地址信息
        public List<UserAddress> ShowressInfo(int UserId)
        {
            return dal.ShowressInfo(UserId);
        }
        //添加新地址
        public int AddressInfo(AddressInfo info)
        {
            return dal.AddressInfo(info);
        }
        //显示订单 
        public List<UserInfo> Dingshow(int UserId)
        {
            return dal.Dingshow(UserId);
        }
    }
}

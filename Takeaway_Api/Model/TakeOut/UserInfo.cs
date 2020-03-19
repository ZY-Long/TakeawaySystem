using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
   public class UserInfo
    {
        //用户Id
        public int Id { get; set; }
        //用户昵称
        public string NickName { get; set; }
        //用户头像
        public string Img { get; set; }
        //用户手机号
        public string PhoneNumber { get; set; }
        //用户密码
        public string PassWord { get; set; }
        //盐
        public int Salt { get; set; }
        //邮箱
        public string Email { get; set; }
        //真实姓名
        public string MyProperty { get; set; }
    }
}

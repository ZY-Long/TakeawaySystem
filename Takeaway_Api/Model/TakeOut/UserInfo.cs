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
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Img { get; set; }
        public string PhoneNumber { get; set; }
    }
}

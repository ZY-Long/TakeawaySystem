using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    /// <summary>
    /// 显示用户地址界面
    /// </summary>
    public class ShowLocationRequest:BaseRequest
    {
        public override string GetApiName()
        {
            return "/api/UserInfo/ShowressInfo";
        }

        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    public class DeLoginRequest : BaseRequest
    {
        //登录
        public override string GetApiName()
        {
            return "/api/UserInfo/InfoResponse";
        }
        public UserInfo User { get; set; }
    }
}

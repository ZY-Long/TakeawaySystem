using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    //显示用户个人订单信息
    public class OrderGeResponse : BaseResponse
    {
        public List<UserInfo> Uuers { get; set; }
    }
}

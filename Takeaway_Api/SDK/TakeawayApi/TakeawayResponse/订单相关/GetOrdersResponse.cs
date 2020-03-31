using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    /// <summary>
    /// 获取用户地址信息相关
    /// </summary>
    public class GetOrdersResponse : BaseResponse
    {
        public List<OrderAddress> addresses { get; set; }
    }
}

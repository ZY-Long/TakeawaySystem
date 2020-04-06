using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    /// <summary>
    /// 获取用户地址信息相关
    /// </summary>
    public class GetOrdersRequest:BaseRequest
    {
        public int Id { get; set; }

        public override string GetApiName()
        {
            return "/api/Order/GetOrders";
        }

    }
}

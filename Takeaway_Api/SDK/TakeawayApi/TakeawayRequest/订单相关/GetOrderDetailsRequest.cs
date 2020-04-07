using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDK
{
    /// <summary>
    /// 获取订单信息请求相关
    /// </summary>
    public class GetOrderDetailsRequest : BaseRequest
    {
        public int UserId { get; set; }

        public override string GetApiName()
        {
            return "/api/Order/GetOrderDetails";
        }
    }
}

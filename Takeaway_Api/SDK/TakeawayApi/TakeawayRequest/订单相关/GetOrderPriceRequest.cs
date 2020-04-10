using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    /// <summary>
    /// 获取订单总价的请求
    /// </summary>
    public class GetOrderPriceRequest:BaseRequest
    {
        public string Ids { get; set; }

        public override string GetApiName()
        {
            return "/api/Order/GetOrderPrice";
        }
    }
}

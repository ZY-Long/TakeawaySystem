using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    /// <summary>
    /// 获取订单总价的返回
    /// </summary>
    public class GetOrderPriceResponse:BaseResponse
    {
        public decimal Toprice { get; set; }
    }
}

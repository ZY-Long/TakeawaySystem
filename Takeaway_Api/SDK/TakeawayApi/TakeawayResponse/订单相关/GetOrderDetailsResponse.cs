using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    /// <summary>
    /// 获取订单详情相关返回
    /// </summary>
    public class GetOrderDetailsResponse:BaseResponse
    {
        public List<OderOrderDetailsShow> orders { get; set; }
    }
}

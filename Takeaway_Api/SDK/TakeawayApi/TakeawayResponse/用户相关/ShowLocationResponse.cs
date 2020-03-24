using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    /// <summary>
    /// 显示用户地址返回
    /// </summary>
    public class ShowLocationResponse:BaseResponse
    {
        public List<UserAddress> Infos { get; set; }
    }
}

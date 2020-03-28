using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    //显示用户个人订单信息
  public   class OrderGeRequest:BaseRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 商家Id
        /// </summary>
        public int BusinessId { get; set; }

        public override string GetApiName()
        {
            return "/api/UserInfo/Dingshow";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
   public  class ShowRequest:BaseRequest
    {
        //显示地址
        public override string GetApiName()
        {
            return "/api/UserInfo/ShowressInfo";
        }
        public AddressInfo user { get; set; }
    }
}

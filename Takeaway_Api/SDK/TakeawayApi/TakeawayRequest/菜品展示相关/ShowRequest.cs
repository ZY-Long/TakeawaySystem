using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.TakeawayApi.TakeawayRequest.菜品展示相关
{
    public class ShowRequest:BaseRequest
    {
        public override string GetApiName()
        {
            return "/api/ShowMenuInfo/Show";
        }
    }
}

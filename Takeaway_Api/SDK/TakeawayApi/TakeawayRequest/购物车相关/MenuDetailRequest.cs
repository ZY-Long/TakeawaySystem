using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
   public class MenuDetailRequest : BaseRequest
    {
        public int userid { get; set; }
        public int menuid { get; set; }
        public override string GetApiName()
        {
            return "/api/MenuDetail/GetMenuDetail";
        }
    }
}

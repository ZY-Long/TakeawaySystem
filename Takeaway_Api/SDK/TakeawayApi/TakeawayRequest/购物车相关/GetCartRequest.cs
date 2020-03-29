using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
   public class GetCartRequest:BaseRequest
    {
        public int userid { get; set; }
        public override string GetApiName()
        {
            return "/api/CratDe/GetCartInfos";
        }
    }
}

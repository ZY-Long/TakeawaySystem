using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDK
{
    public class OneAddressRequest:BaseRequest
    {
        public int UserId { get; set; }

        public int AddressId { get; set; }

        public override string GetApiName()
        {
            return "/api/UserInfo/GetOneAddress";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
   public class UserInfoResponse:BaseResponse
    {
        public List<UserInfo> userInfos { get; set; }
    }
}

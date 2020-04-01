using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace SDK
{
    public class LocationRequest : BaseRequest
    {
        //修改用户地址
        public override string GetApiName()
        {
            return "/api/UserInfo/EditUserInfo";
        }
        public string content { get; set; }

        public int Areaid { get; set; }

        public int UserId { get; set; }

        public int Id { get; set; }
    }
}

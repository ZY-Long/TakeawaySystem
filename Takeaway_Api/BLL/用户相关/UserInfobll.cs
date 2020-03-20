using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public  class UserInfobll
    {
        public int AddUser(UserInfo user)
        {
            return BaseDAL<UserInfoLogin>.Instance.AddUser(user);
        }
    }
}

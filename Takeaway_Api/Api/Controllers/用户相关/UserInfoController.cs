using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;

namespace Api.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfobll bll = new UserInfobll();
        public int AddUser(UserInfo user)
        {
            return bll.AddUser(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;
using SDK;

namespace Api.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfobll bll = new UserInfobll();
        public int AddUser(UserInfo user)
        {
            return bll.AddUser(user);
        }
        public UserInfoResponse InfoResponse(UserRequest request)
        {
            return bll.InfoResponse(request);
        }
        ///修改密码
        ///
        public int EditUserPwd(string pwd, int id)
        {
            return bll.EditUserPwd(pwd,id);
        }
        //修改用户地址
        public int EditUserInfo(string content, int id)
        {
            return bll.EditUserInfo(content, id) ;
        }
    }
}

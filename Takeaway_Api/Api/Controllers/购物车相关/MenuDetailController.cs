using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using SDK;
using Model;
namespace Api
{
    public class MenuDetailController : ApiController
    {
        [HttpPost]
        public MenuDetailResponse GetMenuDetail(MenuDetailRequest request)
        {
            MenuDetailResponse menuresponse = new MenuDetailResponse();
            menuresponse.GetMenu = BaseBLL<TakeBLL>.Instance.GetMenuDetail(request.menuid);
            menuresponse.State = true;
            return menuresponse;
        }
    }
}

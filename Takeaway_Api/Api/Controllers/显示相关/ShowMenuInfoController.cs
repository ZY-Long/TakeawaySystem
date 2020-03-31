using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using SDK;

namespace Api
{
    public class ShowMenuInfoController:ApiController
    {
        [HttpPost]
        public ShowMenuInfoResponse Show(ShowMenuInfoRequest request)
        {
            ShowMenuInfoResponse response = new ShowMenuInfoResponse();
            response.Showw = BaseBLL<FoodShowBLL>.Instance.Show(request.currPage, request.TypeId, request.Name);
            return response;
            
        }

    }
}

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
    public class AddCartDetailsController : ApiController
    {
        [HttpPost]
        public AddCartDetailsResponse AddCartDetails(AddCartDetailsRequest request)
        {
            AddCartDetailsResponse response = new AddCartDetailsResponse();
            response.Add = BaseBLL<TakeBLL>.Instance.AddCartDetails(request.AddCart);
            response.State = true;
            return response;
        }
    }
}

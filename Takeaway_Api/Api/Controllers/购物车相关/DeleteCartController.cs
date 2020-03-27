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
    public class DeleteCartController : ApiController
    {
        [HttpPost]
        public DeleteCartResponse DeleteCart(DeleteCartRequest request)
        {
            DeleteCartResponse response = new DeleteCartResponse();
            response.delete = BaseBLL<TakeBLL>.Instance.DeleteCart(request.id);
            return response;
        }
    }
}

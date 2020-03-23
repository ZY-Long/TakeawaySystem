using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using BLL;
using SDK;
namespace Api
{
    public class AddCartController : ApiController
    {
       
        public AddCartResponse AddCart(CartDetails cart)
        {
             AddCartResponse addCart = new AddCartResponse();
            addCart.add= BaseBLL<TakeBLL>.Instance.AddCartDetails(cart);
            return addCart;
        }
    }
}

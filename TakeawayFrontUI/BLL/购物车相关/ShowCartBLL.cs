using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
namespace BLL
{
   public class ShowCartBLL
    {
        public GetCartResponse GetCart(GetCartRequest request)
        {
            return ApiRequestHelper.Post<GetCartRequest, GetCartResponse>(request);
        }
    }
}

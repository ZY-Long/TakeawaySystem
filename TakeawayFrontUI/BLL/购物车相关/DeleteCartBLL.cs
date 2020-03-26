using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
namespace BLL
{
   public class DeleteCartBLL
    {
        public DeleteCartResponse DeleteCart(DeleteCartRequest request)
        {
            return ApiRequestHelper.Post<DeleteCartRequest, DeleteCartResponse>(request);
        }
    }
}

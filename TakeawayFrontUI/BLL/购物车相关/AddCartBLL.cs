using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
namespace BLL
{
   public class AddCartBLL
    {
        public AddCartDetailsResponse AddCartDetails(AddCartDetailsRequest request)
        {
            return ApiRequestHelper.Post<AddCartDetailsRequest, AddCartDetailsResponse>(request);
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        public AddCartDetailsResponse CartTran(AddCartDetailsRequest request)
        {
            return ApiRequestHelper.Post<AddCartDetailsRequest, AddCartDetailsResponse>(request);
        }
    }
}

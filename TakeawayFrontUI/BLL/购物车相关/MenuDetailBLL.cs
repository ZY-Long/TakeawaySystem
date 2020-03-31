using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
namespace BLL
{
   public class MenuDetailBLL
    {
        public MenuDetailResponse GetMenuDetati(MenuDetailRequest request)
        {
            return ApiRequestHelper.Post<MenuDetailRequest, MenuDetailResponse>(request);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace SDK
{
   public class AddCartDetailsRequest:BaseRequest
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public int count { get; set; }
        public override string GetApiName()
        {
            return "/api/AddCartDetails/AddCartDetails";
        }
    }
}

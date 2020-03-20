using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace SDK
{
   public class CartAddRequest:BaseRequest
    {
        public CartDetails CartAdd { get; set; }
        public override string GetApiName()
        {
            return "/api/Crat/GetArealnfos";
        }
    }
}

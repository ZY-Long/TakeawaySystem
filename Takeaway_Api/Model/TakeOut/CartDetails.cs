using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 购物车详情表
    /// </summary>
   public class CartDetails
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int TypeId { get; set; }
        public int DetailsId { get; set; }
        public int Count { get; set; }
        public int TasteId { get; set; }
    }
}

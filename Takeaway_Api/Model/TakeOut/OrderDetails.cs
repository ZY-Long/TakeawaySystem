using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 订单详情表
    /// </summary>
   public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public int DetailsId { get; set; }
        public int Count { get; set; }
        public int TasteId { get; set; }
        public string Content { get; set; }
    }
}

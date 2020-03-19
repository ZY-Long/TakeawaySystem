using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 订单表
    /// </summary>
   public class OrderInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int State { get; set; }
        public DateTime CreateTime { get; set; }
        public int AddressId { get; set; }
        public string TableNumber { get; set; }
        public int DataState { get; set; }
        public decimal Freight { get; set; }
        public int PackagingFee { get; set; }
        public int TablewareCount { get; set; }
        public int ActivityId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

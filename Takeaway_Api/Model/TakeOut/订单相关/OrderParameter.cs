using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 添加订单信息
    /// </summary>
    public class OrderParameter
    {
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int AddressId { get; set; }


        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Content { get; set; }



        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string Ids { get; set; }

    }
}

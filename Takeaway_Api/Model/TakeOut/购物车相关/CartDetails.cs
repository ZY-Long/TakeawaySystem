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
        /// <summary>
        /// 菜品图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string Name { get; set; }
        //购物车数量
        public int Count { get; set; }
        //总价钱
        public decimal ToPrice { get; set; }
        

    }
}

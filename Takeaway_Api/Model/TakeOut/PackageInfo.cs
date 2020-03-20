using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 套餐表
    /// </summary>
   public class PackageInfo
    {
        //套餐Id
        public int Id { get; set; }
        //套餐名称
        public string Name { get; set; }
        //套餐图片
        public string Img { get; set; }
        //套餐价钱
        public decimal Price { get; set; }
        //类型Id为3是酒水
        public int TypeId { get; set; }
        //备注
        public string Remark { get; set; }
        //商家Id
        public int BusinessInfo { get; set; }
    }
}

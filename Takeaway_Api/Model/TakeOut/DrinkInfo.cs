using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 酒水表
    /// </summary>
   public class DrinkInfo
    {
        //酒水Id
        public int Id { get; set; }
        //酒水名称
        public string Name { get; set; }
        //酒水图片
        public string Img { get; set; }
        //酒水价钱
        public decimal Price { get; set; }
        //类型Id为2是酒水
        public int TypeId { get; set; }
        //酒水备注
        public string Remark { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜品表
    /// </summary>
    public class MenuInfo
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
        public string Remark { get; set; }
    }
}

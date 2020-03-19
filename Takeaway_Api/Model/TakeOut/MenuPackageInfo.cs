using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 套餐菜品关联表
    /// </summary>
   public class MenuPackageInfo
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int TypeId { get; set; }
        public int DetailsId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 销量表
    /// </summary>
   public class SalesInfo
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int DetailsId { get; set; }
        public int Sales { get; set; }
        
    }
}

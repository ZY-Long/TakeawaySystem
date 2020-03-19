using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户地址表
    /// </summary>
   public class AddressInfo
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string Content { get; set; }
    }
}
